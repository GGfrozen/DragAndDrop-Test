using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellController : MonoBehaviour
{
    [Header("Money")]
    [SerializeField] private int playerMoney;
    [SerializeField] private int magazineMoney;

    [Header("MoneyText")]
    [SerializeField] private Text playerMoneyText;
    [SerializeField] private Text magazineMoneyText;

    private void Start()
    {
        SetMoneyText();
    }

    private void SetMoneyText()
    {
        playerMoneyText.text = $"Money: {playerMoney}";
        magazineMoneyText.text = $"Money: {magazineMoney}";
    }

    public bool BuyItem(Items item)
    {
        if (playerMoney - item.cost >= 0)
        {
            playerMoney -= item.cost;
            magazineMoney += item.cost;
            SetMoneyText();
            return true;
        }

        return false;
    }

    public bool SellItem(Items item)
    {
        if (magazineMoney - item.cost >= 0)
        {
            playerMoney += item.cost;
            magazineMoney -= item.cost;
            SetMoneyText();
            return true;
        }

        return false;
    }

}
