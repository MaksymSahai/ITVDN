using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    public Transform AttackStartPosition;
    public GameObject[] AttackPrefabs;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAttack()
    {
        _animator.SetTrigger("Attack");
        int index = Random.Range(0, AttackPrefabs.Length);

        GameObject attObj = Instantiate(AttackPrefabs[index]) as GameObject;
        attObj.transform.position = AttackStartPosition.position;
        Destroy(attObj, 0.15f);
    }
}
