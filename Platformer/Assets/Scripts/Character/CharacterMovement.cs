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

    Animator animator;

    private Rigidbody2D rigidbody2D;
    private float tolerance = 0.01f;
    //private bool isFacingRight;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //isFacingRight = true;
    }


    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColiderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);

        //Debug.Log(rigidbody2D.velocity.normalized);
    }

    public void Move(float direction, bool isJump)
    {
        if(isJump)
        {
            Jump();
            //animator.SetBool("IsJump", false);
        }

        if(Mathf.Abs(direction) > tolerance)
        {
            HorizontalMovement(direction);
            //animator.SetFloat("Speed", Mathf.Abs(direction));
        }


    }

    private void HorizontalMovement(float direction)
    {
        rigidbody2D.velocity = new Vector2(animationCurve.Evaluate(direction) * speed, rigidbody2D.velocity.y);
        if(direction < 0 )
        {
            spriteRenderer.flipX = true;
            //Debug.Log(isFacingRight);
        }
        else
        {
            spriteRenderer.flipX = false;
            //Debug.Log(isFacingRight);
        }
        animator.SetFloat("Speed", Mathf.Abs(direction));

    }

    public void Jump()
    {
        float timer = Time.time ;
            //animator.SetBool("IsJump", false);
        if (isGrounded)
        {
            //animator.SetBool("IsJump", true);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            //Debug.Log(rigidbody2D.velocity.normalized.y * jumpForce);
            timer -= Time.captureDeltaTime;
            Debug.Log(timer);

            //if (rigidbody2D.velocity.normalized.y * jumpForce < jumpForce)
            //{
            //    animator.SetBool("IsJump", isGrounded);
            //
        }
            //timer = Time.time;
        //animator.SetBool("IsJump", false);
    }

    private void Flip()
    {

    }
}
