using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    private CharacterMovement movement;

    void Start()
    {
        movement = new CharacterMovement();
    }

    // Update is called once per frame
    void Update()
    {

        movement.Move();
    }
}
