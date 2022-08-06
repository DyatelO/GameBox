using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerInput : IMovementIbput
{
    public float Directon { get; private set; }
    public bool IsJump { get; private set; }

    public void ReadInput()
    {
        Directon = Input.GetAxis(TagInput.HORIZONTAL_AXIS);
        //Debug.Log(Directon);
        IsJump = Input.GetButtonDown(TagInput.JUMP_BUTTON);

    }

    public void ReadButtonPressedInput()
    {
        IsJump = Input.GetButtonDown(TagInput.JUMP_BUTTON);
    }


}