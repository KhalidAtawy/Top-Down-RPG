using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator currentAnimator;
    [SerializeField] RuntimeAnimatorController greenAnimator;
    [SerializeField] RuntimeAnimatorController blueAnimator;
    [SerializeField] RuntimeAnimatorController redAnimator;
    [SerializeField] RuntimeAnimatorController pinkAnimator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        GetPlayerAxisInput();
        SetPlayerAnimationDirection();
    }

    private void GetPlayerAxisInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
    }

    private void SetPlayerAnimationDirection()
    {
        currentAnimator.SetFloat("Horizontal", movement.x);
        currentAnimator.SetFloat("Vertical", movement.y);
        currentAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // move the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    public void ChangeItemColor(ItemsTypes itemType)
    {
        switch (itemType)
        {
            case ItemsTypes.GreenSkin:
                // todo: change player color
                currentAnimator.runtimeAnimatorController = greenAnimator;
                break;

            case ItemsTypes.BlueSkin:
                // todo: change player color
                currentAnimator.runtimeAnimatorController = blueAnimator;
                break;

            case ItemsTypes.RedSkin:
                // todo: change player color
                currentAnimator.runtimeAnimatorController = redAnimator;
                break;

            case ItemsTypes.PinkSkin:
                // todo: change player color
                currentAnimator.runtimeAnimatorController = pinkAnimator;
                break;

            default:
                // todo: change player color
                currentAnimator.runtimeAnimatorController = greenAnimator;
                break;
        }
    }
}
