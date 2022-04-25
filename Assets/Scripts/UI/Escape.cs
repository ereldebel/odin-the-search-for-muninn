using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class Escape : MonoBehaviour
	{
		private static Escape _instance;
		private void Awake()
		{
			if (_instance != null)
			{
				Destroy(this);
				return;
			}

			_instance = this;
			DontDestroyOnLoad(this);
		}

		[SerializeField] private KeyCode quitButton = KeyCode.Escape;
		private void Update()
		{
			if (!Input.GetKeyDown(quitButton)) return;
			if (SceneManager.GetActiveScene().name == "Tutorial")
				SceneManager.LoadScene("Game");
			else if (SceneManager.GetActiveScene().name == "Game")
				SceneManager.LoadScene("Start");
			else
			{
				Application.Quit();
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#endif
			}
		}
	}
}