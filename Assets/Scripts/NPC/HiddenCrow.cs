using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NPC
{
    public class HiddenCrow : MonoBehaviour, IHittable
    {
        private Animator _animator;
        private static readonly int Hit = Animator.StringToHash("Take Hit");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void TakeHit()
        {
            AudioManager.CrowReleased();
            _animator.SetTrigger(Hit);
            Invoke("WinScene", 1.0f);
        }

        private void WinScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (sceneName == "Game")
                SceneManager.LoadScene("GameOverWin", LoadSceneMode.Single);
            else
                SceneManager.LoadScene("Game");
        }

    }
}