using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ControllContainer : ScriptableObject
{
    [SerializeField] GameObject character;
    [SerializeField] private float speed; //AiInput;

    public bool IsAi;
}
