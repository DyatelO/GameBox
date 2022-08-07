using System;
using UnityEngine;

[Serializable]
public class MotionMovement
{
    private IMovementInput movementInput;
    private Rigidbody2D rigidbody2D;
    private MovementSettings movementSettings;



    private float startDragParameter;
    private float stopParameter = 1000;
    //private float lastVelocity;

    public MotionMovement(IMovementInput MovementInput, Rigidbody2D Rigidbody, MovementSettings MovementSettings)
    {
        this.movementInput = MovementInput;
        this.rigidbody2D = Rigidbody;
        this.movementSettings = MovementSettings;

        startDragParameter = rigidbody2D.drag; //movementSettings.MoveSpeed;
    }

    public void Tick()
    {
        Move();
    }

    public void Move()
    {
            rigidbody2D.velocity = new Vector2(movementSettings.MoveSpeed * movementInput.Directon, rigidbody2D.velocity.y);
    }

    public void Move(float speed)
    {
        rigidbody2D.velocity = new Vector2(speed * movementInput.Directon, rigidbody2D.velocity.y);
    }

    public void StopCharacter()
    {
        //float stop = 0;
        //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x - lastVelocity, rigidbody2D.velocity.y);

        rigidbody2D.drag = stopParameter;

    }

}