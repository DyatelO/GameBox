using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : IMovementInput
{
    public float Directon { get; private set; }
    public bool IsJump { get; private set; }

    public bool IsPunch => throw new System.NotImplementedException();

    public void ReadInput()
    {
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