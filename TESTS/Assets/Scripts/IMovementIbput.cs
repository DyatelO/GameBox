using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementIbput
{
    public float Directon { get; }
    public bool IsJump { get; }

    public void ReadInput();
    //{
    //    Debug.Log("MovementIbput");
    //}

    public void ReadButtonPressedInput();


}