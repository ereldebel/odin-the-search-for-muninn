using UnityEngine;

public class Tutorial : MonoBehaviour
{
	[SerializeField] private GameObject[] explanations;

	private int _tutorialLevel = 0;
	private bool changed = false;

	private void Update()
	{
		if (((_tutorialLevel < 3 || (_tutorialLevel > 4 && _tutorialLevel < explanations.Length)) &&
		     Input.GetKeyDown(KeyCode.Return)) ||
		    ((_tutorialLevel == 3 || _tutorialLevel == 4) && Input.GetMouseButtonDown(0)))
		{
			explanations[_tutorialLevel].SetActive(false);
			explanations[++_tutorialLevel].SetActive(true);
		}
	}
}