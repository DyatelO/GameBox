using System;
using UnityEngine;

[Serializable]
public class MotionMovement
{
    private IMovementInput movementInput;
    private Rigidbody2D rigidbody2D;
    private MovementSettings movementSettings;

    private float startMoveSpeed;

    public MotionMovement(IMovementInput MovementInput, Rigidbody2D Rigidbody, MovementSettings MovementSettings)
    {
        this.movementInput = MovementInput;
        this.rigidbody2D = Rigidbody;
        this.movementSettings = MovementSettings;

        startMoveSpeed = movementSettings.MoveSpeed;
    }

    public void Tick()
    {
        Move();
    }

    public void Move()
    {
        rigidbody2D.velocity = new Vector2(movementSettings.MoveSpeed * movementInput.Directon, rigidbody2D.velocity.y);
    }

}