using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public Transform StartPosition;
    
    public GameObject GoldPrefab;
    public GameObject[] MonstersPrefabs;

    public Text PlayerGoldUI;
    public int PlayerGold;


    // Use this for initialization
    void Start()
    {
        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString();
    }

    public void TakeGold(int gold)
    {
        PlayerGold += gold;

        GameObject goldObj =  Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObj, 2);

        SpawnMonster();
    }

    public void SpawnMonster()
    {
        int index = 0;

        GameObject monsterObj = Instantiate(MonstersPrefabs[index]) as GameObject;

        monsterObj.transform.position = StartPosition.position;
    }
}
