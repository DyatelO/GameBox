using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterInput : MonoBehaviour
{
    private CharacterMovement movement;
    void Start()
    {
        movement = GetComponent<CharacterMovement>();
        //movement.JumpForce = JumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonOn = Input.GetButtonDown(GlobalStringVars.JUMP);

        movement.Move(horizontalDirection, isJumpButtonOn);
    }

    //private void FixedUpdate()
    //{
    //    if(IsJumpButtonOn)
    //        movement.JumpForce = JumpForce;
    //    movement.Jump(Rigidbody2d);
    //}
}
