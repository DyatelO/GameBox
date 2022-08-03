using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;

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

    public void SetFacingDirection(float direction)
    {
        if(direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            if(direction < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
