using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private MovementSettings movementSettings;
    public GameObject attackPoint;

    private IMovementIbput movementIbput;
    private MotionMovement motionMovement;
    private Rigidbody2D rigidbody2D;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private MotionAnimation motionAnimation;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        motionAnimation = new MotionAnimation(animator, spriteRenderer);

        if(movementSettings.UseAI)
        {
            movementIbput = new AiInput();
        }
        else
        {
            movementIbput = new ControllerInput();
        }

        motionMovement = new MotionMovement(movementIbput, rigidbody2D, movementSettings);



    }

    private void Update()
    {
        movementIbput.ReadInput();
        movementIbput.ReadButtonPressedInput();
        motionMovement.Jump();

        HandlePlayerAnimations();
    }

    private void FixedUpdate()
    {
        //motionMovement.Tick();
        //motionAnimation.PlayWalkAnimation(Mathf.Abs(rigidbody2D.velocity.x));
        motionMovement.Move();        
        //motionMovement.Jump();      
    }

    private void HandlePlayerAnimations()
    {
        motionAnimation.PlayWalkAnimation(Mathf.Abs(rigidbody2D.velocity.x));
        motionAnimation.SetFacingDirection(rigidbody2D.velocity.x);

        //Debug.Log(facing);

       // motionAnimation.PlayJumpAnimation(!isGround);
    }

} //
