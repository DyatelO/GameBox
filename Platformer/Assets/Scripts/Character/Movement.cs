using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.2f;
    [SerializeField] private float jumpForce = 3.2f;

    private Rigidbody2D rigidbody2D;

    private Vector3 tempPosition;

    private PlayerAnimation playerAnimation;

    //float horizontalDirection;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        //horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        //HandleMovementWithTransform(horizontalDirection);

        HandlePlayerAnimations();
    }

    private void FixedUpdate()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        HandleMovementWithRigidBody2D(horizontalDirection);
    }

    private void HandleMovementWithTransform(float direction)
    {
        //float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);

        tempPosition = transform.position;

        if(Mathf.Abs(direction) > 0  )// Mathf.Abs(direction) > 0 )
        {
            tempPosition.x += direction * moveSpeed * Time.deltaTime;;
        }

        transform.position = tempPosition;
    }

    private void HandleMovementWithRigidBody2D(float direction)
    {
        if (Mathf.Abs(direction) > 0)
        {
            rigidbody2D.velocity = new Vector2(moveSpeed * direction, rigidbody2D.velocity.y);
        }
    }

    private void HandlePlayerAnimations()
    {
        playerAnimation.PlayWalkAnimation(Mathf.Abs(rigidbody2D.velocity.x));
        playerAnimation.SetFacingDirection(rigidbody2D.velocity.x);

        //Debug.Log();
    }
}
