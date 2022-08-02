using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;

    [Header("Settings")]
    [SerializeField] private Transform groundColiderTransform;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rigidbody2D;
    private float tolerance = 0.01f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColiderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
        
    }

    public void Move(float direction, bool isJump)
    {
        if(isJump)
        {
            Jump();
        }

        if(Mathf.Abs(direction) > tolerance)
        {
            HorizontalMovement(direction);
        }
    }

    private void HorizontalMovement(float direction)
    {
        rigidbody2D.velocity = new Vector2(animationCurve.Evaluate(direction) * speed, rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        if(isGrounded)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
    }
}
