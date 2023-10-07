using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 0f;

    private void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period; // constantly groing over time
        const float tau = Mathf.PI * 2; // getting value 6.smth for sin wave
        float rawSineWave = Mathf.Sin(cycles * tau); // creates sinus wave; returns values from -1 to 1.

        movementFactor = (rawSineWave + 1) / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = offset + startingPosition;
    }

    public void SetPeriod(float value)
    {
        period = value;
    }
}
