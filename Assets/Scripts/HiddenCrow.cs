using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenCrow : MonoBehaviour, IHittable
{

    public void TakeHit()
    {
        Invoke("WinScene", 1);
    }

    private void WinScene()
    {
        SceneManager.LoadScene("GameOverWin", LoadSceneMode.Single);
    }

}