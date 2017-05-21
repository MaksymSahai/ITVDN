using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagment
{
    public class MainMenuHelper : MonoBehaviour
    {

        private void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                StartGame();
        }
    }
}
