using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : IMovementInput
{
    public float Directon { get; private set; }
    public bool IsJump { get; private set; }

    public bool IsPunch { get; private set; }

    [SerializeField] private GameObject player = null;

    private void FindPlayer()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<Player>().gameObject;
        else
            return;
    }

    public void ReadInput()
    {
        
        FindPlayer();
        Directon = Vector2.left.x;
        //IsJump = ;
    }

    public void ReadButtonPressedInput()
    {
        return;
    }

    public void PressPunch()
    {
        return;
    }
}