using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
    public class HeroHelper : MonoBehaviour
    {
        public GameObject BulletPrefab;
        public int Damage = 10;
        public float AttackSpeed = 2.0f;



        /// <summary>
        /// Start method to hero, start attack coroutine.
        /// </summary>
        void Start()
        {
            StartCoroutine(Attack());
        }

        /// <summary>
        /// Attack coroutines.
        /// </summary>
        /// <returns>Damage from hero one per AttackSpeed.</returns>
        IEnumerator Attack()
        {
            yield return new WaitForSeconds(AttackSpeed);

            GameObject bullet = Instantiate(BulletPrefab) as GameObject;
            bullet.transform.position = transform.position;
            bullet.GetComponent<BulletHealper>().Damage = Damage;

            StartCoroutine(Attack());
        }
    }
}
