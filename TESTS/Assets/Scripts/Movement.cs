using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private MovementSettings movementSettings;
    //[SerializeField] 
    private Transform GroundCheckTransform;
    public GameObject attackPoint;

    private IMovementInput movementIbput;
    //[SerializeField] 
    [SerializeField] private MotionMovement motionMovement;
    [SerializeField] private JumpMovement jumpMovement;
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

    }

    private void Update()
    {
        movementIbput.ReadInput();
        movementIbput.ReadButtonPressedInput();
        //motionMovement.Jump();
        //
        jumpMovement.Jump();
        //
        HandlePlayerAnimations();
    }

    private void FixedUpdate()
    {
        motionMovement.Move();
        jumpMovement.IsOnGround();
 
    }

    private void HandlePlayerAnimations()
    {
        motionAnimation.PlayWalkAnimation(Mathf.Abs(rigidbody2D.velocity.x));
        motionAnimation.SetFacingDirection(rigidbody2D.velocity.x);

        //Debug.Log(facing);

       motionAnimation.PlayJumpAnimation(!jumpMovement.IsGround);
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