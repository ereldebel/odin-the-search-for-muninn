using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartGame : MonoBehaviour
    {
    
        private void Update()
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
            }
        }
    }
}
