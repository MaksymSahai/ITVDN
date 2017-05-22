using GameManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class HealthHelper : MonoBehaviour
    {
        public int RubyChanse = 0;

        public int MaxHealth = 100;
        public int Health = 100;
        public int Gold = 90;
        public float TimeToKill = 3.0f;

        private GameHelper _gameHelper;
        private Animator _animator;

        private bool _isDead = false;

        /// <summary>
        /// Start Method to initialization health healper.
        /// </summary>
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _gameHelper = GameObject.FindObjectOfType<GameHelper>();
            _gameHelper.HealthSlider.maxValue = MaxHealth;
            _gameHelper.HealthSlider.value = MaxHealth;
            _gameHelper.HealthText.text = Health.ToString() + "/" + MaxHealth.ToString();
            _gameHelper.HealthText.color = Color.green;
        }

        /// <summary>
        /// Gets damage to monster.
        /// </summary>
        /// <param name="damage">Damage value.</param>
        public void GetHit(int damage)
        {
            if (_isDead)
                return;

            int health = Health - damage;


            if (health <= 0)
            {
                _isDead = true;
                _gameHelper.TakeGold(Gold);

                int random = Random.Range(0, 100);
                if (random < RubyChanse)
                    _gameHelper.TakeRuby(1);

                Destroy(gameObject);
            }

            _animator.SetTrigger("Hit");
            Health = health;
            _gameHelper.HealthSlider.value = Health;

            if ((MaxHealth / 3) * 2 > Health)
                _gameHelper.HealthText.color = Color.yellow;

            if (MaxHealth / 3 >= Health)
                _gameHelper.HealthText.color = Color.red;

            _gameHelper.HealthText.text = Health.ToString() + "/" + MaxHealth.ToString();
        }
    }
}
