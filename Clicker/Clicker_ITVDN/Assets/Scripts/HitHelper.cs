using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class HitHelper : MonoBehaviour
    {
        private Animator _animator;
        private HealthHelper _healthHelper;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _healthHelper = GetComponent<HealthHelper>();
        }

        private void OnMouseDown()
        {
            _animator.SetTrigger("Hit");
            _healthHelper.GetHit(10);
        }
    }
}
