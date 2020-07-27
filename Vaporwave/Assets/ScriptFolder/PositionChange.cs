using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PositionChange: MonoBehaviour
{
    [SerializeField] private float movementVector = 3f;
    private float startingPos = 25f;

    void Start()
    {
    }

    void Update()
    {
        float time = Time.time;
        float rawSinWave = (-1f * (Mathf.Cos(time * 2 * Mathf.PI / BPSTiming.getSPB()))+ 1f) * 0.5f;
        float offset = rawSinWave * movementVector;
        transform.localPosition = new Vector3(transform.localPosition.x, startingPos + offset, transform.localPosition.z);
    }
}
