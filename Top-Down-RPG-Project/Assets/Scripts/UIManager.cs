using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    [SerializeField] Animator shopAnimator;
    [SerializeField] Animator InventoryAnimator;
    public GameObject dialogueUI;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    // ===== Buttons
    public void HomeBtnShopPressed()
    {
        CloseShopAnimation();
    }
    public void HomeBtnInventoryPressed()
    {
        CloseInventoryAnimation();
    }
    public void InventoryBtnPressed()
    {
        if (InventoryAnimator.gameObject.activeSelf != true)
            OpenInventoryAnimation();
        else
            CloseInventoryAnimation();
    }

    public void ShopOkBtnPressed()
    {
        dialogueUI.SetActive(false);
        OpenShopAnimation();
    }

    public void ShopCancelBtnPressed()
    {
        dialogueUI.SetActive(false);
    }

    public void ExitGameBtnPressed()
    {
        Application.Quit();
    }

    // ===== Aimations
    public void OpenShopAnimation()
    {
        CloseInventoryAnimation();
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
        CloseShopAnimation();
        InventoryAnimator.gameObject.SetActive(true);
        InventoryAnimator.SetBool("CloseInventory", false);
        InventoryAnimator.SetBool("OpenInventory", true);
    }

    public void CloseInventoryAnimation()
    {
        InventoryAnimator.SetBool("OpenInventory", false);
        InventoryAnimator.SetBool("CloseInventory", true);
    }

}
