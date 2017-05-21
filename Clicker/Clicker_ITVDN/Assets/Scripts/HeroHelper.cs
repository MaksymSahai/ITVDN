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



        // Use this for initialization
        void Start()
        {
            StartCoroutine(Attack());
        }

        // Update is called once per frame
        void Update()
        {
        }

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
