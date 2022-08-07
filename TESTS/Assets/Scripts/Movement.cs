using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private MovementSettings movementSettings;
    [SerializeField] private PunchSettings punchSettings;
    //[SerializeField] 
    private Transform GroundCheckTransform;
    //public 
    private Transform attackPoint;

    private IMovementInput movementIbput;
    //[SerializeField] 
    [SerializeField] private MotionMovement motionMovement;
    [SerializeField] private JumpMovement jumpMovement;
    [SerializeField] private Punch punch;
    //
    private Rigidbody2D rigidbody2D;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private MotionAnimation motionAnimation;



    private void Awake()
    {
        //
        GroundCheckTransform = GetComponentInChildren<CircleCollider2D>().transform;

        //
        rigidbody2D = GetComponent<Rigidbody2D>();
        //
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        motionAnimation = new MotionAnimation(animator, spriteRenderer);
        //
        if(movementSettings.UseAI)
        {
            movementIbput = new AiInput();
        }
        else
        {
            movementIbput = new ControllerInput();
        }

        motionMovement = new MotionMovement(movementIbput, rigidbody2D, movementSettings);
        //
        jumpMovement = new JumpMovement(movementIbput, rigidbody2D, movementSettings, GroundCheckTransform);
        //jumpMovement = new JumpMovement(motionMovement, GroundCheckTransform);
        //
        attackPoint = GetComponentInChildren<PunchPoint>().transform;
        punch = new Punch(movementIbput, punchSettings, attackPoint);
        //

    }

    private void Update()
    {
        //if (movementIbput.IsPunch && jumpMovement.IsGround)     //movementIbput.Directon != 0)
        //{
        //    motionMovement.StopCharacter();
        //}


        movementIbput.ReadInput();
        //movementIbput.ReadButtonPressedInput(); // Важно
        //movementIbput.PressPunch();
        //motionMovement.Jump();
        //
        jumpMovement.Jump();
        //
        
        punch.HandleAttack();
        //

        //
        HandlePlayerAnimations();
    }

    private void FixedUpdate()
    {
        //if ( jumpMovement.IsGround)
        //{
        //    if(punch.IsPunch )
        //        motionMovement.StopCharacter();
        //}

        motionMovement.Move();
        jumpMovement.IsOnGround();
    }

    private void HandlePlayerAnimations()
    {
        motionAnimation.PlayWalkAnimation(Mathf.Abs(rigidbody2D.velocity.x));
        motionAnimation.SetFacingDirection(rigidbody2D.velocity.x);

        //Debug.Log(facing);

       motionAnimation.PlayJumpAnimation(!jumpMovement.IsGround);

        if (punch.IsPunch)
            motionAnimation.PlayPunchAnimation();
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, punchSettings.AttackRange);
    }
    private void SetMoveSpeedWithPunch()
    {
        //if (punch.IsPunch && jumpMovement.IsGround)
        //{
        //    motionMovement.StopCharacter();
        //}
    }



} //


    // DOpolnit'
    //---------
    //private void SetMoveSpeedWithPunch()
    //{
    //    //if(isGround)
    //    //{

    //    //}
    //    if (isPunch && jumpMovement.IsGround == true)
    //    {
    //        moveSpeed /= 100;
    //    }
    //    else
    //    {
    //        moveSpeed = startMoveSpeed;
    //    }
    //}
    //--------------