using UnityEngine;

namespace Managers
{
	public class TutorialManager : MonoBehaviour
	{
		[SerializeField] private GameObject[] explanations;

		private int _tutorialLevel = 0;

		private void Update()
		{
			// if (((_tutorialLevel < 3 || (_tutorialLevel > 4 && _tutorialLevel < explanations.Length - 1)) &&
			//      Input.GetKeyDown(KeyCode.Return)) ||
			//     ((_tutorialLevel == 3 || _tutorialLevel == 4) && Input.GetMouseButtonDown(0)))
			if (Input.GetKeyDown(KeyCode.Return) && _tutorialLevel < explanations.Length - 1)
			{
				explanations[_tutorialLevel].SetActive(false);
				explanations[++_tutorialLevel].SetActive(true);
			}
		}
	}
}