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
                amountText.text = Inventory.instance.Items[itemType].ToString();
                return;
            }
        }

    }

    public void UseItemBtnPressed()
    {
        Inventory.instance.UseItem(itemType, amountText);
    }

    public void HomeBtnPressed()
    {
        UIManager.instance.CloseShopAnimation();
    }
}
