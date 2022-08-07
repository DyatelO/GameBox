using System;
using UnityEngine;

[Serializable]
public class MotionAnimation 
{
    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;

    public MotionAnimation(Animator Animator, SpriteRenderer SpriteRenderer)
    {
        this.animator = Animator;
        this.spriteRenderer = SpriteRenderer;
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
        if (direction > 0)
        {
            spriteRenderer.flipX = false;

            //attackPoint.transform.position = positionScale;
        }
        else
        {
            if (direction < 0)
            {
                spriteRenderer.flipX = true;
                //attackPoint.transform.position = -positionScale;
            }
        }
        return spriteRenderer.flipX;
    }

    public void PlayPunchAnimation()
    {
        animator.SetTrigger(TagAnimation.ATTACK_ANIMATION_TRIGGER_PARAMETER);
        //animator.SetFloat(TagAnimation.WALK_ANIMATION_PARAMETER, 0);
    }


}   //
