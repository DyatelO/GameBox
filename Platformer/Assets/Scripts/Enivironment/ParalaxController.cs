using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeffts;

    private int layersCount;

    private void Awake()
    {
        layersCount = layers.Length;
    }

    private void Update()
    {
        for (int i = 0; i < layersCount; i++)
        {
            layers[i].position = transform.position * coeffts[i];
        }
    }
}
