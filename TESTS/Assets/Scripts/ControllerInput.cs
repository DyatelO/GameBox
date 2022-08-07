using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerInput : IMovementInput
{
    public float Directon { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsPunch { get; private set; }


    [SerializeField] private bool isMove ;

    public void ReadInput()
    {
        Directon = Input.GetAxis(TagInput.HORIZONTAL_AXIS);

        if(IsPunch && Directon != 0)
        {
            Directon = 0;
        }

        IsJump = Input.GetButtonDown(TagInput.JUMP_BUTTON);
        IsPunch = Input.GetButtonDown(TagInput.ATTACK_BUTTON);
    }
}