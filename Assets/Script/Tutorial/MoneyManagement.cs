using UnityEngine;
using TMPro;

public class MoneyManagement : MonoBehaviour {

    public TextMeshProUGUI TotalGoldText;
    public TextMeshProUGUI BulletText;
    public TextMeshProUGUI BombText;

    public TextMeshProUGUI DisplayBombText;
    public TextMeshProUGUI DisplayBulletText;

    private int BulletBuy = 5;
    private int BombBuy = 3;

   
    private int TotalMoney = 0;

    private void Start()
    {
        TotalMoney = PlayerPrefs.GetInt("TotalCoin", 0);
        TotalGoldText.text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
    }

    private void Update()
    {
        TotalGoldText.text = TotalMoney.ToString();
    }

    public void AddBullet() {
        if (TotalMoney >= BulletBuy)
        {
            TotalMoney -= BulletBuy;
            BulletText.text = (int.Parse(BulletText.text) + 1).ToString();
        }
        else {
            //Sound of Poverty;
        }
    }

    public void AddBomb()
    {
        if (TotalMoney >= BombBuy)
        {
            TotalMoney -= BombBuy;
            BombText.text = (int.Parse(BombText.text) + 1).ToString();
        }
        else
        {
            //Sound of Poverty;
        }
    }

    public void RemoveBullet()
    {
        if (int.Parse(BulletText.text) > 0)
        {
            TotalMoney += BulletBuy;
            BulletText.text = (int.Parse(BulletText.text) - 1).ToString();
        }
    }

    public void RemoveBomb()
    {
        if (int.Parse(BombText.text) > 0)
        {
            TotalMoney += BombBuy;
            BombText.text = (int.Parse(BombText.text) - 1).ToString();
        }
    }

    public void DoneButton()
    {
        DisplayBombText.text = (int.Parse(BombText.text)+int.Parse(DisplayBombText.text)).ToString();
        DisplayBulletText.text = (int.Parse(BulletText.text)+int.Parse(DisplayBulletText.text)).ToString();
        BulletText.text = "0";
        BombText.text = "0";
        PlayerPrefs.SetInt("TotalCoin" , TotalMoney);
    }
}
