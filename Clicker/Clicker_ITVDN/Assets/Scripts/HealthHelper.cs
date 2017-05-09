using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class HealthHelper : MonoBehaviour
    {
        public int MaxHealth = 100;
        public int Health = 100;
        public int Gold = 90;

        private GameHelper _gameHelper;


        // Use this for initialization
        private void Start()
        {
            _gameHelper = GameObject.FindObjectOfType<GameHelper>();
            _gameHelper.HealthSlider.maxValue = MaxHealth;
            _gameHelper.HealthSlider.value = MaxHealth;
        }

        public void GetHit(int damage)
        {
            int health = Health - damage;

            if (health <= 0)
            {
                _gameHelper.TakeGold(Gold);
                Destroy(gameObject);
            }

            Health = health;
            _gameHelper.HealthSlider.value = Health;
        }
    }
}
