using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagment
{
    public class MainMenuHelper : MonoBehaviour
    {
        /// <summary>
        /// Mehtod Load game scene from main menu.
        /// </summary>
        private void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        /// <summary>
        /// Method liesener of click on screen to start game.
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                StartGame();
        }
    }
}
