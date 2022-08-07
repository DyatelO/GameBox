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
        //if(!movementInput.IsJump)
        //{
        //    if(movementInput.IsPunch && movementInput.Directon != 0)
        //    {
        //        rigidbody2D.drag *= 2000;
        //        rigidbody2D.velocity = Vector2.zero.normalized;
        //    }
        //    else
        //    {
        //        rigidbody2D.drag = 0;
        //    }
        //}
        if(!movementInput.IsJump)
        {
            while(Mathf.Abs(movementInput.Directon) > 0.2f)
            {
                if(movementInput.IsPunch)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * 0, rigidbody2D.velocity.y) ;
                    break;
                }
            }
        }


        rigidbody2D.velocity = new Vector2(movementSettings.MoveSpeed * movementInput.Directon, rigidbody2D.velocity.y);


    }

    public void StopCharacter()
    {
        //float stop = 0;
        //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x - lastVelocity, rigidbody2D.velocity.y);

        rigidbody2D.drag = stopParameter;

    }

}