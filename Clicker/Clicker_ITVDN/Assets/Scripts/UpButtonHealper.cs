using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHealper : MonoBehaviour
{
    public GameObject UpPrefab;
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
        if (_gameHelper.PlayerGold >= Price)
        {
            _gameHelper.PlayerGold -= Price;
            _gameHelper.PlayerDamage += Damage;

            GameObject upObj = Instantiate(UpPrefab) as GameObject;
            Transform canvas = GameObject.Find("Canvas").transform;
            upObj.transform.SetParent(canvas);
            upObj.GetComponent<Image>().sprite = IconImage.sprite;
            Destroy(upObj, 055f);

            Destroy(gameObject);
        }
    }
}
