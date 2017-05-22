using Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
    public class BulletHealper : MonoBehaviour
    {

        private HealthHelper _healthHelper;

        /// <summary>
        /// Gets or sets bullet damage.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        void Update()
        {
            if (_healthHelper == null)
                _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    _healthHelper.transform.position,
                    Time.deltaTime * 10f);

                if (Vector2.Distance(transform.position, _healthHelper.transform.position) < 0.1f)
                {
                    _healthHelper.GetHit(Damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
