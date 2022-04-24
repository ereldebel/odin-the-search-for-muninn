using UnityEngine;

public class AudioManager : MonoBehaviour
{
	#region Serialized fields

	[SerializeField, Tooltip("Clips by index:\n0\tCrow Found\n1\tCrow Released\n2\tKomuso Death\n3\tNinja Attack\n4\tNinja Death\n5\tNinja Spawn\n6\tOdin Attack\n7\tOdin Death\n8\tOdin Hit")]
	private AudioClip[] clips;
	[SerializeField] private AudioClip gameplayMusic;

	#endregion

	#region Private fields

	private static AudioManager _shared;
	private AudioSource _audio;

	#endregion

	#region Function events

	private void Awake()
	{
		if (_shared != null)
		{
			Destroy(gameObject);
			return;
		}

		_shared = this;
		DontDestroyOnLoad(gameObject);
		_audio = GetComponent<AudioSource>();
	}

	#endregion

	#region Public methods

	public static void SwitchToGameplayMusic()
	{
		_shared._audio.clip = _shared.gameplayMusic;
	}

	public static void CrowFound() => PlayClipByIndex(0);

	public static void CrowReleased() => PlayClipByIndex(1);

	public static void KomusoDeath() => PlayClipByIndex(2);

	public static void NinjaAttack() => PlayClipByIndex(3);
	
	public static void NinjaDeath() => PlayClipByIndex(4);

	public static void NinjaSpawn() => PlayClipByIndex(5);
	
	public static void OdinAttack() => PlayClipByIndex(6);
	
	public static void OdinDeath() => PlayClipByIndex(7);

	public static void OdinHit() => PlayClipByIndex(8);

	#endregion

	#region Private Methods

	private static void PlayClipByIndex(int clipIndex)
	{
		if (clipIndex < _shared.clips.Length && _shared.clips[clipIndex] != null)
			_shared._audio.PlayOneShot(_shared.clips[clipIndex]);
	}

	#endregion
}