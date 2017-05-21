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

        public void ShowEndScore(int gold)
        {
            if (PlayerPrefs.GetInt("GorlRecord") < gold)
                PlayerPrefs.SetInt("GorlRecord", gold);

            EndScore.text = gold.ToString();
            Record.text = PlayerPrefs.GetInt("GorlRecord").ToString();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}