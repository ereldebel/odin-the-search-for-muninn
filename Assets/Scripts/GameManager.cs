using System;
using NPC;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	#region Serialized Fields

	[Tooltip("The transform of Odin.")] [SerializeField]
	private Transform odin;

	[Tooltip("Komuso prefab.")] [SerializeField]
	private GameObject komuso;

	[Tooltip("Disguised ninja prefab.")] [SerializeField]
	private GameObject disguisedNinja;

	[Tooltip("Disguised crow prefab.")] [SerializeField]
	private GameObject disguisedCrow;

	[Tooltip("The number of rows of NPCs in the level.")] [SerializeField]
	private int numNPCRows = 50;

	[Tooltip("The number of columns of NPCs in the level.")] [SerializeField]
	private int numNPCCols = 50;

	[Tooltip("The width (in number of NPCs) of the first ring around the disguised crow.")] [SerializeField]
	private int firstNinjaRingWidth = 5;

	[Tooltip("The width (in number of NPCs) of the second ring around the disguised crow.")] [SerializeField]
	private int secondNinjaRingWidth = 5;

	[Tooltip("The width (in number of NPCs) of the third ring around the disguised crow.")] [SerializeField]
	private int thirdNinjaRingWidth = 5;

	[Tooltip("Probability of a komuso in the the second ring being a ninja.")] [SerializeField]
	private float secondNinjaRingProb = 0.7f;

	[Tooltip("Probability of a komuso in the the third ring being a ninja.")] [SerializeField]
	private float thirdNinjaRingProb = 0.2f;

	[Tooltip("Probability of a komuso outside the third ring being a ninja.")] [SerializeField]
	private float outsideNinjaProb = 0.1f;

	[Tooltip("Max distance of an NPC from it's grid position.")] [SerializeField]
	private float positionNoise = 2;

	[Tooltip("The radius of hte circle around Odin at the start of the game that no NPC spawns in.")] [SerializeField]
	private float startNoNPCRadius = 2;

	[SerializeField] private int numOfOdinLives = 3;
	[SerializeField] private int numOfKomusoLives = 5;
	[SerializeField] private bool spawnNPC = true;
	[SerializeField] private bool killingNinjasRefillsKomusoHealth = true;

	#endregion

	#region Private Fields

	private static GameManager _shared;
	private float _komusoHeight;
	private float _disguisedNinjaHeight;
	private int _remainingOdinLives;
	private int _remainingKomusoLives;


	private const int MaxDist = 45;

	#endregion

	#region Public Properties

	public static int NumOfOdinLives => _shared.numOfOdinLives;
	public static int NumOfKomusoLives => _shared.numOfKomusoLives;

	public static NinjaPool NinjaPool { get; private set; }
	public static Transform Odin { get; private set; }

	#endregion

	#region Function Events

	private void Awake()
	{
		_shared = this;
		NinjaPool = GetComponent<NinjaPool>();
		Odin = odin;
		_komusoHeight = komuso.transform.position.y;
		_disguisedNinjaHeight = disguisedNinja.transform.position.y;
		_remainingOdinLives = numOfOdinLives;
		_remainingKomusoLives = numOfKomusoLives;
		if (spawnNPC)
			PlaceNPCs();
	}

	#endregion
	
	
	#region Public C# Events
	public static event Action OdinTookHit;
	public static event Action KomusoTookHit;
	public static event Action NinjaTookHit;
	
	#endregion

	#region Private Methods

	private void PlaceNPCs()
	{
		var distBetweenRows = (float) (2 * MaxDist) / numNPCRows;
		var distBetweenCols = (float) (2 * MaxDist) / numNPCCols;
		var thirdOfRows = numNPCRows / 3;
		var thirdOfCols = numNPCCols / 3;
		var crowI = Random.Range(0, thirdOfRows);
		var crowJ = Random.Range(0, thirdOfCols);
		if (Random.value > 0.5f) crowI = crowI * 3 + crowI % 3;
		if (Random.value > 0.5f) crowJ = crowJ * 3 + crowJ % 3;

		for (var i = 0; i < numNPCRows; ++i)
		{
			for (var j = 0; j < numNPCCols; ++j)
			{
				var pos = PickPosition(distBetweenRows, distBetweenCols, i, j);
				if (pos.magnitude < startNoNPCRadius) continue;
				if (i == crowI && j == crowJ)
				{
					pos.y = disguisedCrow.transform.position.y;
					Instantiate(disguisedCrow, pos, disguisedCrow.transform.rotation);
					continue;
				}

				if (math.abs(i - crowI) + math.abs(j - crowJ) < firstNinjaRingWidth)
				{
					InstantiateDisguisedNinja(pos);
					continue;
				}

				if (math.abs(i - crowI) + math.abs(j - crowJ) < secondNinjaRingWidth)
				{
					if (Random.value > secondNinjaRingProb)
						InstantiateKomuso(pos);
					else
						InstantiateDisguisedNinja(pos);
					continue;
				}

				if (math.abs(i - crowI) + math.abs(j - crowJ) < thirdNinjaRingWidth)
				{
					if (Random.value > thirdNinjaRingProb)
						InstantiateKomuso(pos);
					else
						InstantiateDisguisedNinja(pos);
					continue;
				}

				if (Random.value > outsideNinjaProb)
					InstantiateKomuso(pos);
				else
					InstantiateDisguisedNinja(pos);
			}
		}
	}

	private void InstantiateDisguisedNinja(Vector3 pos)
	{
		pos.y = _disguisedNinjaHeight;
		Instantiate(disguisedNinja, pos, disguisedNinja.transform.rotation);
	}

	private void InstantiateKomuso(Vector3 pos)
	{
		pos.y = _komusoHeight;
		Instantiate(komuso, pos, komuso.transform.rotation);
	}

	private Vector3 PickPosition(float distBetweenRows, float distBetweenCols, int i, int j)
	{
		var basicPosition = new Vector3(i * distBetweenRows - MaxDist, 0, j * distBetweenCols - MaxDist);
		for (var _ = 0; _ < 30; ++_)
		{
			var distance = Random.Range(0, positionNoise);
			var randomPoint = basicPosition + Random.insideUnitSphere * distance;
			if (!NavMesh.SamplePosition(randomPoint, out var hit, 1.0f, NavMesh.AllAreas)) continue;
			return hit.position;
		}

		return Vector3.zero;
	}

	#endregion

	#region Public Methods

	public static void OdinHit()
	{
		if (--_shared._remainingOdinLives == 0)
			SceneManager.LoadScene("GameOverLose", LoadSceneMode.Single);
		else
			OdinTookHit?.Invoke();
	}

	public static void KomusoHit()
	{
		if (--_shared._remainingKomusoLives == 0)
			SceneManager.LoadScene("GameOverLose", LoadSceneMode.Single);
		else
			KomusoTookHit?.Invoke();
	}
	
	public static void NinjaHit()
	{
		if (!_shared.killingNinjasRefillsKomusoHealth) return;
		if (_shared._remainingKomusoLives++ == _shared.numOfKomusoLives) return;
		NinjaTookHit?.Invoke();
	}

	#endregion
}