using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    /// <summary>
    /// Event Added at the end of close Animation
    /// </summary>
    public void EndCloseMenuEvent()
    {
        animator.SetBool("OpenShop", false); 
        animator.SetBool("CloseShop", false);
        gameObject.SetActive(false);
    }
}
