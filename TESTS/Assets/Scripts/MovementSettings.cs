using UnityEngine;

[CreateAssetMenu(menuName = "Character/Settings", fileName = "MovementData")]
public class MovementSettings : ScriptableObject
{
    [SerializeField] private float moveSpeed = 1.2f;
    [SerializeField] private float jumpForce = 3.2f;
    [SerializeField] private bool useAi = false;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGround = false;
    [SerializeField] private float jumpOffset;
    [SerializeField] private Transform groundCheckTransform;

    public LayerMask GroundMask { get { return groundMask; } }
    public bool IsGround { get { return isGround; } }
    public float JumpOffset { get { return jumpOffset; } }
    public Transform GroundCheckTransform { get { return groundCheckTransform; } }
    /// <summary>
    /// 
    /// </summary>
    public float MoveSpeed { get { return moveSpeed; } }
    public float JumpForce { get { return jumpForce; } }
    public bool UseAI { get { return useAi; } }
}