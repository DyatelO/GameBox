using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch 
{
    [SerializeField] private bool isPunch = false;
    private CircleCollider2D circleCollider2D;

    public Transform attackPoint;
    Vector2 position;
    float offsetPoint; //= attackPoint.localPosition.x;
    [SerializeField] public float attackRange = 0.5f;
    [SerializeField] public float attackRate = 2f;
    private float nextAttackTime = 0f;
    [SerializeField] private LayerMask enemyMask;



    private void HandleAttack()   // (float direction)
    {

        if (Time.time >= nextAttackTime)
        {
            //playerAnimation.PlayPunchAnimation();
            isPunch = false;

            //Vector2 punchPos = rigidbody2D.velocity;
            if (Input.GetButtonDown(TagInput.ATTACK_BUTTON))
            {
                //playerAnimation.PlayPunchAnimation();
                isPunch = true;

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyMask);

                foreach (Collider2D enemy in hitEnemies)
                {
                    Debug.Log("We hit " + enemy.name);
                }

                nextAttackTime = Time.time + 1f / attackRate;

            }

        }
    }
}
