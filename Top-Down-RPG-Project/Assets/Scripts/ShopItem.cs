using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private int itemAmount;
    [SerializeField] private ItemsTypes itemType;
    [SerializeField] TextMeshProUGUI amountText;
    [SerializeField] TextMeshProUGUI priceText;
    public int price;

    private void Awake()
    {
        priceText.text = price.ToString();
    }
    public void BuyBtnPressed()
    {
        Inventory.instance.BuyItem(itemType, amountText, price);
    }

    public void SellBtnPressed()
    {
        Inventory.instance.SellItem(itemType, amountText, price);
    }


}
