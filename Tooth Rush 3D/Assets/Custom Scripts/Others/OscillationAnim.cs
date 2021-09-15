using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillationAnim : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    [Range(0, 1)] [SerializeField] float movementFactor;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }


    private void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles *tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startPos + offset;
    }
}
