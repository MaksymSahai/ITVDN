using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public Slider HealthSlider;
    public Transform StartPosition;

    public GameObject GoldPrefab;
    public GameObject[] MonstersPrefabs;

    public Text PlayerGoldUI;
    public Text DamageTextUI;

    public int PlayerGold;
    public int PlayerDamage = 10;


    // Use this for initialization
    void Start()
    {
        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString();
        DamageTextUI.text = PlayerDamage.ToString();
    }

    public void TakeGold(int gold)
    {
        PlayerGold += gold;
        GameObject goldObj = Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObj, 1);
        SpawnMonster();
    }

    public void SpawnMonster()
    {
        int index = Random.Range(0, MonstersPrefabs.Length);
        GameObject monsterObj = Instantiate(MonstersPrefabs[index]) as GameObject;
        monsterObj.transform.position = StartPosition.position;
    }
}
