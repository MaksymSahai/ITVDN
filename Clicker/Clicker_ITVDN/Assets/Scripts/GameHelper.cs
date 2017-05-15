using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    const int Freeq = 3;

    public EndMenuHealper EndMenuHealper;

    public float GameTime = 10;
    public Text GameTimeTextUI;
    public Slider HealthSlider;
    public Transform StartPosition;

    public GameObject GoldPrefab;
    public GameObject RubyPrefab;
    public GameObject[] MonstersPrefabs;

    public Text PlayerGoldUI;
    public Text RubyTextUI;
    public Text DamageTextUI;

    public int PlayerGold;
    public int PlayerRuby;
    public int PlayerDamage = 10;

    private int _count = 0;
    private int _totalPlayerGold;
    private float _currentTime;

    public bool EndGame { get; private set; }


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        SpawnMonster();
        InvokeRepeating("Timer", time: 0, repeatRate: 1);
    }

    void Timer()
    {
        _currentTime++;
        GameTimeTextUI.text = (GameTime - _currentTime).ToString();
        if (_currentTime >= GameTime)
        {
            Time.timeScale = 0;
            EndGame = true;
            EndMenuHealper.gameObject.SetActive(true);
            EndMenuHealper.ShowEndScore(_totalPlayerGold);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString();
        RubyTextUI.text = PlayerRuby.ToString();
        DamageTextUI.text = PlayerDamage.ToString();

    }

    public void TakeGold(int gold)
    {
        PlayerGold += gold;
        _totalPlayerGold += gold;
        GameObject goldObj = Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObj, 1);
        SpawnMonster();
    }

    public void TakeRuby(int ruby)
    {
        PlayerRuby += ruby;
        GameObject rubyObj = Instantiate(RubyPrefab) as GameObject;
        Destroy(rubyObj, 3);
    }

    public void SpawnMonster()
    {
        _count++;
        int randomMaxValue = _count / Freeq + 1;

        if (randomMaxValue >= MonstersPrefabs.Length)
            randomMaxValue = MonstersPrefabs.Length;

        int index = Random.Range(0, randomMaxValue);

        GameObject monsterObj = Instantiate(MonstersPrefabs[index]) as GameObject;
        monsterObj.transform.position = StartPosition.position;
    }
}
