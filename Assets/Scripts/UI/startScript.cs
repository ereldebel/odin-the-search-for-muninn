using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartScript : MonoBehaviour
    {
    
        [SerializeField] private GameObject logo;
        private float speed;

        private void Update()
        {
            float y = Mathf.PingPong(Time.time * speed, 100); // * 6 - 3;
            logo.transform.position = new Vector3(0, y, 0);
        
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
            }
        }
    }
}
