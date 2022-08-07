using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementInput
{
    public float Directon { get; }
    public bool IsJump { get; }
    public bool IsPunch { get; }

    public void ReadInput();
    public void ReadButtonPressedInput();


}//