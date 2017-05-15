using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHealper : MonoBehaviour
{

    public GameObject UpPrefab;
    public GameObject HeroPrefab;

    public bool IsHero;
    public bool IsRuby;
    public Text DamageText;
    public Text PriceText;
    public Image IconImage;

    public int Damage = 5;
    public int Price = 100;

    private GameHelper _gameHelper;

    // Use this for initialization
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpClick()
    {
        if (!IsRuby && _gameHelper.PlayerGold >= Price
            || 
            IsRuby && _gameHelper.PlayerRuby >= Price)
        {
            if (!IsRuby)
            {
                _gameHelper.PlayerGold -= Price;
            }
            else
            {
                _gameHelper.PlayerRuby -= Price;
            }

            if (!IsHero)
            {
                _gameHelper.PlayerDamage += Damage;
            }
            else
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;
                Vector2 heroPos = new Vector2(Random.Range(3.5f, 7.0f), -1.7f);
                hero.transform.position = heroPos;

            }

            GameObject upObj = Instantiate(UpPrefab) as GameObject;
            Transform canvas = GameObject.Find("Canvas").transform;
            upObj.transform.SetParent(canvas);
            upObj.GetComponent<Image>().sprite = IconImage.sprite;
            Destroy(upObj, 055f);


            if (!IsHero)
            {
                Destroy(gameObject);
            }
        }
    }
}
