using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    [SerializeField] Animator shopAnimator;
    [SerializeField] Animator InventoryAnimator;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    public void HomeBtnPressed()
    {
        UIManager.instance.CloseShopAnimation();
    }

    public void OpenShopAnimation()
    {
        shopAnimator.gameObject.SetActive(true);
        shopAnimator.SetBool("CloseShop", false);
        shopAnimator.SetBool("OpenShop", true);
    }

    public void CloseShopAnimation()
    {
        shopAnimator.SetBool("OpenShop", false);
        shopAnimator.SetBool("CloseShop", true);
    }

    public void OpenInventoryAnimation()
    {
        gameObject.SetActive(true);
        InventoryAnimator.SetBool("CloseInventory", false);
        InventoryAnimator.SetBool("OpenInventory", true);
    }

    public void CloseInventoryAnimation()
    {
        InventoryAnimator.SetBool("OpenInventory", false);
        InventoryAnimator.SetBool("CloseInventory", true);
    }

}
