using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartOnEnter : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}
