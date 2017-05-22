using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace GameManagment
{
    public class EndMenuHealper : MonoBehaviour
    {
        public Text EndScore;
        public Text Record;

        /// <summary>
        /// Method show total score after end of game.
        /// </summary>
        /// <param name="gold"></param>
        public void ShowEndScore(int gold)
        {
            if (PlayerPrefs.GetInt("GorlRecord") < gold)
                PlayerPrefs.SetInt("GorlRecord", gold);

            EndScore.text = gold.ToString();
            Record.text = PlayerPrefs.GetInt("GorlRecord").ToString();
        }

        /// <summary>
        /// Method restart game after end of game.
        /// </summary>
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /// <summary>
        /// Method load main menu from end game screen.
        /// </summary>
        public void LoadMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}