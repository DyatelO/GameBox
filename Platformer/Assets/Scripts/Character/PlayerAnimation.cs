using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject attackPoint;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void PlayWalkAnimation(float walk)
    {
        animator.SetFloat(TagAnimation.WALK_ANIMATION_PARAMETER, walk);
    }

    public void PlayJumpAnimation(bool isJump)
    {
        animator.SetBool(TagAnimation.JUMP_ANIMATION_PARAMETER, isJump);
    }

    public bool SetFacingDirection(float direction)
    {

        //Vector3 positionScale = attackPoint.transform.position;
        if(direction > 0)
        {
            spriteRenderer.flipX = false;

            //attackPoint.transform.position = positionScale;
        }
        else
        {
            if(direction < 0)
            {
                spriteRenderer.flipX = true;
                //attackPoint.transform.position = -positionScale;
            }
        }
        return spriteRenderer.flipX;

//new Vector2(direction, attackPoint.transform.position.y);
    }

    //public void PlayPunchAnimation(bool isPunch)
    //{
    //    animator.SetBool(TagAnimation.ATTACK_ANIMATION_PARAMETER, isPunch);
    //}

    public void PlayPunchAnimation()
    {
        animator.SetTrigger(TagAnimation.ATTACK_ANIMATION_TRIGGER_PARAMETER);
    }

    public void PlayHurtAnimation(bool isHuer)
    {
        animator.SetTrigger(TagAnimation.ATTACK_ANIMATION_TRIGGER_PARAMETER);

    }


}   //
