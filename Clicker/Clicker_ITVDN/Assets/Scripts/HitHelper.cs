using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class HitHelper : MonoBehaviour
    {
        private Animator _animator;
        private HealthHelper _healthHelper;

        GameHelper _gameHelper;
        PlayerHelper _playerHelper;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _healthHelper = GetComponent<HealthHelper>();
            _gameHelper = GameObject.FindObjectOfType<GameHelper>();
            _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
        }

        private void OnMouseDown()
        {
            _animator.SetTrigger("Hit");
            _healthHelper.GetHit(_gameHelper.PlayerDamage);
            _playerHelper.RunAttack();
        }
    }
}
