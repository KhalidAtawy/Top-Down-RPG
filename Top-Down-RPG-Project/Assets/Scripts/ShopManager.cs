using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Animator animator;


    public void EndCloseShopEvent()
    {
        animator.SetBool("OpenShop", false);
        gameObject.SetActive(false);
    }

    public void OpenShopAnimation()
    {
        gameObject.SetActive(true);
        animator.SetBool("CloseShop", false);
        animator.SetBool("OpenShop", true);
    }

    public void CloseShopAnimation()
    {
        animator.SetBool("OpenShop", false);
        animator.SetBool("CloseShop", true);
    }
}
