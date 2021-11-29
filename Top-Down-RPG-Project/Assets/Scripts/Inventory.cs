using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class Inventory : MonoBehaviour
{
    public static Inventory instance = null;

    [SerializeField] GameObject player;

    [Header("UI References")]
    public int goldAmount;
    [SerializeField] TextMeshProUGUI TotalGoldText;
    public ItemsTypes currentItem;
    public Dictionary<ItemsTypes, int> Items = new Dictionary<ItemsTypes, int>();
    [SerializeField] List<InventoryItem> inventoryItems = new List<InventoryItem>();


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// initialize values used in the UI
    /// </summary>
    private void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentItem = ItemsTypes.GreenSkin;
        TotalGoldText.text = goldAmount.ToString();

        Items.Add(ItemsTypes.GreenSkin, 0);
        Items.Add(ItemsTypes.BlueSkin, 0);
        Items.Add(ItemsTypes.PinkSkin, 0);
        Items.Add(ItemsTypes.RedSkin, 0);
    }

    /// <summary>
    /// buy the item only if we have less than 99 of this item in the inventory
    /// </summary>
    /// <param name="itemType"></param>
    public void BuyItem(ItemsTypes itemType, TextMeshProUGUI amountText, int price)
    {
        foreach (var item in Items)
        {
            if (itemType == item.Key && item.Value < 99 && goldAmount >= price)
            {
                goldAmount -= price;
                TotalGoldText.text = goldAmount.ToString();
                Items[itemType]++;
                amountText.text = Items[itemType].ToString();
                return;
            }
        }
    }

    /// <summary>
    /// sell the item only if we have at least one of this item in the inventory
    /// </summary>
    /// <param name="itemType"></param>
    public void SellItem(ItemsTypes itemType, TextMeshProUGUI amountText, int price)
    {
        foreach (var item in Items)
        {
            if (itemType == item.Key && item.Value > 0)
            {
                goldAmount += price;
                TotalGoldText.text = goldAmount.ToString();
                Items[itemType]--;
                amountText.text = Items[itemType].ToString();
                return;
            }
        }
    }

    /// <summary>
    /// used to change the color and set which skin is the current
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="amountText"></param>
    public void UseItem(ItemsTypes itemType, TextMeshProUGUI amountText)
    {
        if (Items[itemType] > 0)
        {
            // increase the one the player was wearing
            Items[currentItem]++;
            amountText.text = Items[currentItem].ToString();

            player.GetComponent<PlayerController>().ChangeItemColor(itemType);

            // decrease the one the player will wear and set it as current
            currentItem = itemType;
            Items[itemType]--;
            amountText.text = Items[itemType].ToString();
        }
        foreach (var item in inventoryItems)
        {
            item.ResetUI();
        }
    }
}


public enum ItemsTypes
{
    GreenSkin,
    BlueSkin,
    RedSkin,
    PinkSkin
};
