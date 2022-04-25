using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    
    [SerializeField] private GameObject logo;
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 100); // * 6 - 3;
        logo.transform.position = new Vector3(0, y, 0);
        
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        }
    }
}
