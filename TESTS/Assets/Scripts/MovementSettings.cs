using UnityEngine;

[CreateAssetMenu(menuName = "Character/Settings", fileName = "MovementData")]
public class MovementSettings : ScriptableObject
{
    [SerializeField] private float moveSpeed = 1.2f;
    [SerializeField] private float jumpForce = 3.2f;
    [SerializeField] private bool useAi = false;

    public float MoveSpeed { get { return moveSpeed; } }
    public float JumpForce { get { return jumpForce; } }
    public bool UseAI { get { return useAi; } }
}