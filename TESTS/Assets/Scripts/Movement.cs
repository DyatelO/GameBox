using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private MovementSettings movementSettings;

    private MovementIbput movementIbput;
    private MotionMovement motionMovement;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if(movementSettings.UseAI)
        {
            movementIbput = new AiInput();
        }
        else
        {
            movementIbput = new ControllerInput();
        }

        motionMovement = new MotionMovement(movementIbput, rigidbody2D, movementSettings);
    }

    private void Update()
    {
        movementIbput.ReadInput();
        movementIbput.ReadButtonPressedInput();
        motionMovement.Jump();
    }

    private void FixedUpdate()
    {
        //motionMovement.Tick();
        motionMovement.Move();        
        //motionMovement.Jump();      
    }

} //
