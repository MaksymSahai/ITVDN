using GameManagment;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class HitHelper : MonoBehaviour
    {
        private HealthHelper _healthHelper;

        private GameHelper _gameHelper;
        private PlayerHelper _playerHelper;

        /// <summary>
        /// Start mehtod.
        /// </summary>
        private void Start()
        {
            
            _healthHelper = GetComponent<HealthHelper>();
            _gameHelper = GameObject.FindObjectOfType<GameHelper>();
            _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
        }

        /// <summary>
        /// Method on Click on monster.
        /// </summary>
        private void OnMouseDown()
        {
            if (_gameHelper.EndGame)
                return;

            _healthHelper.GetHit(_gameHelper.PlayerDamage);
            _playerHelper.RunAttack();
        }
    }
}
