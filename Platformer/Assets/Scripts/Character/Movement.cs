using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //[SerializeField] 

    [SerializeField] private float moveSpeed = 1.2f;
    private float startMoveSpeed;
    [SerializeField] private float jumpForce = 3.2f;

    private Rigidbody2D rigidbody2D;

    private Vector3 tempPosition;

    private PlayerAnimation playerAnimation;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGround = false;
    [SerializeField] private float jumpOffset ;
    [SerializeField] private Transform groundCheckTransform;

    [SerializeField] private bool isPunch = false;
    private CircleCollider2D circleCollider2D;

    public Transform attackPoint;
    Vector2 position;
    float offsetPoint; //= attackPoint.localPosition.x;
    [SerializeField] public float attackRange = 0.5f;
    [SerializeField] public float attackRate = 2f;
    private float nextAttackTime = 0f;
    [SerializeField] private LayerMask enemyMask;

    float horizontalDirection;
    bool facing; //= false;
    //bool isPunch = true;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        groundCheckTransform = GetComponentInChildren<CircleCollider2D>().transform;

        offsetPoint = attackPoint.localPosition.x;

        startMoveSpeed = moveSpeed;
        //position.x = attackPoint.localPosition.x;
        //attackPoint = GetComponentInChildren<Transform>().transform;
    }

    private void Update()
    {
        HandlePlayerAnimations();

        HandleJumping();

        //HndleAttack();
        HandleAttack();
    }

    private void FixedUpdate()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        HandleMovementWithRigidBody2D(horizontalDirection);

        IsOnGround();
    }

    private void HandleMovementWithRigidBody2D(float direction)
    {
        position = attackPoint.localPosition;
        if (Mathf.Abs(direction) > 0)
        {
            rigidbody2D.velocity = new Vector2(moveSpeed * direction, rigidbody2D.velocity.y);
        }

        if ( direction > 0)      //direction > 0 )
        {
            position.x = offsetPoint;

        }
        if (direction < 0 )
        {
            //position.x = attackPoint.localPosition.x - attackPoint.localPosition.x * 2;
            position.x = -offsetPoint;
        }
        SetMoveSpeedWithPunch();


        //Debug.Log(position.x);
        attackPoint.localPosition = position;
    }

    private void SetMoveSpeedWithPunch()
    {
        //if(isGround)
        //{

        //}
        if (isPunch && isGround == true)
        {
            moveSpeed /= 100;
        }
        else
        {
            moveSpeed = startMoveSpeed;
        }
    }

    private void HandlePlayerAnimations()
    {
        playerAnimation.PlayWalkAnimation(Mathf.Abs(rigidbody2D.velocity.x));
        playerAnimation.SetFacingDirection(rigidbody2D.velocity.x);

        //Debug.Log(facing);

        playerAnimation.PlayJumpAnimation(!isGround);
    }

    private void HandleJumping()
    {
        if(Input.GetButtonDown(TagAnimation.JUMP_BUTTON))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isGround)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }

    private void IsOnGround()
    {
        Vector3 overlapCirclePosition = groundCheckTransform.position;
        isGround = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    //private void HandleAttack()
    //{
    //    if(Input.GetButtonDown(TagAnimation.ATTACK_BUTTON))
    //    {
    //        isPunch = true;
    //    }
    //}

    private void HandleAttack()   // (float direction)
    {

        if (Time.time >= nextAttackTime)
        {
            //playerAnimation.PlayPunchAnimation();
            isPunch = false;

                //Vector2 punchPos = rigidbody2D.velocity;
            if(Input.GetButtonDown(TagAnimation.ATTACK_BUTTON))
            {
                playerAnimation.PlayPunchAnimation();
                isPunch = true;

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyMask);

                foreach(Collider2D enemy in hitEnemies)
                {
                    Debug.Log("We hit " + enemy.name) ;
                }

                nextAttackTime = Time.time + 1f / attackRate;

            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}   //
