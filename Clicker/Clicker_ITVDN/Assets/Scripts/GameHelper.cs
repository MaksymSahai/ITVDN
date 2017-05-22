using Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace GameManagment
{
    public class GameHelper : MonoBehaviour
    {
        const int Freeq = 3;

        public EndMenuHealper EndMenuHealper;

        public Text GameTimeTextUI;
        public Slider HealthSlider;
        public Text HealthText;
        public Transform StartPosition;

        public GameObject GoldPrefab;
        public GameObject RubyPrefab;
        public GameObject[] MonstersPrefabs;

        public Text PlayerGoldUI;
        public Text RubyTextUI;
        public Text DamageTextUI;

        public int PlayerGold;
        public int PlayerRuby;
        public int PlayerDamage = 10;

        private int _count = 0;
        private int _totalPlayerGold;
        private float _currentTime;
        private HealthHelper _healthHelper;

        /// <summary>
        /// Gets or private sets is game over.
        /// </summary>
        public bool EndGame { get; private set; }


        /// <summary>
        /// Start method for game healper.
        /// </summary>
        void Start()
        {
            _currentTime = 0;
            Time.timeScale = 1;
            SpawnMonster();
            _healthHelper = FindObjectOfType<HealthHelper>();
        }     

        /// <summary>
        /// Display Gui one per frame.
        /// </summary>
        void Update()
        {
            PlayerGoldUI.text = PlayerGold.ToString();
            RubyTextUI.text = PlayerRuby.ToString();
            DamageTextUI.text = PlayerDamage.ToString();

        }

        /// <summary>
        /// Increase player gold. 
        /// </summary>
        /// <param name="gold">Gold Value.</param>
        public void TakeGold(int gold)
        {
            PlayerGold += gold;
            _totalPlayerGold += gold;
            GameObject goldObj = Instantiate(GoldPrefab) as GameObject;
            Destroy(goldObj, 1);
            SpawnMonster();
        }

        /// <summary>
        /// Increase player ruby.
        /// </summary>
        /// <param name="ruby">Ruby value.</param>
        public void TakeRuby(int ruby)
        {
            PlayerRuby += ruby;
            GameObject rubyObj = Instantiate(RubyPrefab) as GameObject;
            Destroy(rubyObj, 3);
        }

        /// <summary>
        /// Method spawn new monster after kill prev.
        /// </summary>
        public void SpawnMonster()
        {
            _count++;
            _currentTime = 0;
            InvokeRepeating("Timer", time: 0, repeatRate: 1);
            int randomMaxValue = _count / Freeq + 1;

            if (randomMaxValue >= MonstersPrefabs.Length)
                randomMaxValue = MonstersPrefabs.Length;

            int index = UnityEngine.Random.Range(0, randomMaxValue);

            GameObject monsterObj = Instantiate(MonstersPrefabs[index]) as GameObject;
            monsterObj.transform.position = StartPosition.position;
        }

        /// <summary>
        /// Method counter time to kill current monster.
        /// </summary>
        void Timer()
        {
            _currentTime++;
            GameTimeTextUI.text = "Time left: " + (_healthHelper.TimeToKill - _currentTime).ToString();
            if (_currentTime >= _healthHelper.TimeToKill)
            {
                Time.timeScale = 0;
                EndGame = true;
                EndMenuHealper.gameObject.SetActive(true);
                EndMenuHealper.ShowEndScore(_totalPlayerGold);
            }
        }
    }
}
