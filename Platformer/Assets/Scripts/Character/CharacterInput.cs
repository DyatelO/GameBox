using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterInput : MonoBehaviour
{
    private CharacterMovement movement;
    //private Animator animator;

    private void Awake()
    {
        //animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        movement = GetComponent<CharacterMovement>();
        //movement.JumpForce = JumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonOn = Input.GetButtonDown(GlobalStringVars.JUMP);

        //Debug.Log(horizontalDirection);

        movement.Move(horizontalDirection, isJumpButtonOn);

        //if()
    }

    //private void FixedUpdate()
    //{
    //    if(IsJumpButtonOn)
    //        movement.JumpForce = JumpForce;
    //    movement.Jump(Rigidbody2d);
    //}
}
