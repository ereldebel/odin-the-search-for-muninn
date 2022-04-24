using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NPC
{
    public class HiddenCrow : MonoBehaviour, IHittable
    {

        public void TakeHit()
        {
            Invoke("WinScene", 1.0f);
        }

        private void WinScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (sceneName == "Game")
            {
                SceneManager.LoadScene("GameOverWin", LoadSceneMode.Single);
            }
            
        }

    }
}