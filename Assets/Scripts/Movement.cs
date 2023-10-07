using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustingSpeed = 700f;
    [SerializeField] float rotateSpeed = 100f;


    [SerializeField] ParticleSystem mainThrusterParticle;
    [SerializeField] ParticleSystem leftThrusterParticle;
    [SerializeField] ParticleSystem rightThrusterParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    // Thrusting
    public void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }

    // Rotating
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }


    private void StartThrust()
    {
        rb.AddRelativeForce(thrustingSpeed * Time.deltaTime * Vector3.up);
        if (!mainThrusterParticle.isPlaying)
        {
            mainThrusterParticle.Play();
        }
    }

    private void StopThrust()
    {
        mainThrusterParticle.Stop();
    }

    private void Rotate(float rotationSpeedAndDirection)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationSpeedAndDirection * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }

    private void RotateRight()
    {
        Rotate(-rotateSpeed);
        if (!rightThrusterParticle.isPlaying)
        {
            rightThrusterParticle.Play();
        }
    }

    private void RotateLeft()
    {
        Rotate(rotateSpeed);
        if (!leftThrusterParticle.isPlaying)
        {
            leftThrusterParticle.Play();
        }
    }

    private void StopRotating()
    {
        leftThrusterParticle.Stop();
        rightThrusterParticle.Stop();
    }

}
