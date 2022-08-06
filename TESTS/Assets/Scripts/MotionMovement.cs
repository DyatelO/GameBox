using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionMovement
{
    private readonly IMovementIbput movementIbput;
    private Rigidbody2D rigidbody2D;
    private MovementSettings movementSettings;

    public MotionMovement(IMovementIbput MovementIbput, Rigidbody2D Rigidbody, MovementSettings MovementSettings)
    {
        this.movementIbput = MovementIbput;
        this.rigidbody2D = Rigidbody;
        this.movementSettings = MovementSettings;
    }

    public void Tick()
    {
        Move();

        Jump();
    }

    public void Move()
    {
        rigidbody2D.velocity = new Vector2(movementSettings.MoveSpeed * movementIbput.Directon, rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        if(movementIbput.IsJump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, movementSettings.JumpForce);
        }        
    }
}