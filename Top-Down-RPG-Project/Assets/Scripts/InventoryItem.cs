using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private ItemsTypes itemType;
    [SerializeField] TextMeshProUGUI amountText;

    private void OnEnable()
    {
        foreach (var item in Inventory.instance.Items)
        {
            if (itemType == item.Key)
            {
                ResetUI();
                return;
            }
        }

    }

    public void UseItemBtnPressed()
    {
        Inventory.instance.UseItem(itemType, amountText);

    }

    public void ResetUI()
    {
        amountText.text = Inventory.instance.Items[itemType].ToString();
    }

    public void HomeBtnPressed()
    {
        UIManager.instance.CloseShopAnimation();
    }
}
