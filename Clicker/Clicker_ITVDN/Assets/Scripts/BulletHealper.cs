using Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHealper : MonoBehaviour
{

    private HealthHelper _healthHelper;
    public int Damage { get; set; }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
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
