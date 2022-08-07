using System;
using UnityEngine;

[Serializable]
public class JumpMovement 
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGround = false;
    [SerializeField] private float jumpOffset;
    [SerializeField] private Transform groundCheckTransform;

    private float jumpForce;

    private Rigidbody2D rigidbody2D;
    private IMovementInput movementInput;
    private MovementSettings settings;

    private bool isDoubleJump;
    public bool IsGround { get { return isGround; } }

    public JumpMovement(IMovementInput MovementInput,
                        Rigidbody2D Rigidbody2D,
                        MovementSettings Settings,
                        Transform GroundCheck)
                        
    {
        this.groundMask = Settings.GroundMask;
        this.isGround = Settings.IsGround;
        this.jumpOffset = Settings.JumpOffset;
        this.jumpForce = Settings.JumpForce;
        this.groundCheckTransform = GroundCheck;
        this.rigidbody2D = Rigidbody2D;
        this.movementInput = MovementInput;
        this.settings = Settings;

    }

    public void Jump()
    {
        if (movementInput.IsJump)
        {
            if(isGround)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, settings.JumpForce);
            }
        }
    }

    public void IsOnGround()
    {
        Vector3 overlapCirclePosition = groundCheckTransform.position;
        isGround = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }
}
