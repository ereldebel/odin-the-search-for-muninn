using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class tutorialScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI[] explanations;

    private int clickEsc = 0;
    private bool changed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            clickEsc++;
            changed = true;
        }
        switch (clickEsc)
        {
            case 1:
                if (changed)
                {
                    explanations[0].enabled = false;
                    explanations[1].enabled = true;
                    changed = false;
                }
                break;
            case 2:
                if (changed)
                {
                    explanations[1].enabled = false;
                    explanations[2].enabled = true;
                    changed = false;
                }
                break;
            case 3:
                explanations[2].enabled = false;
                explanations[3].enabled = true;
                break;
            case 4:
                explanations[3].enabled = false;
                explanations[4].enabled = true;
                break;
            case 5:
                explanations[4].enabled = false;
                explanations[5].enabled = true;
                break;
            case 6:
                explanations[5].enabled = false;
                explanations[6].enabled = true;
                break;
            case 7:
                explanations[6].enabled = false;
                explanations[7].enabled = true;
                break;
            case 8:
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
                break;
                
        }
    }
}
