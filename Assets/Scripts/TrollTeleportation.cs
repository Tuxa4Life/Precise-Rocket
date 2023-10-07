using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollTeleportation : MonoBehaviour
{
    [SerializeField] float pointX;
    [SerializeField] float pointY;

    [SerializeField] GameObject landingPoint;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y > pointY && transform.position.x < pointX)
        {
            landingPoint.transform.position = new Vector3(30.84f, 0.5f, 0f);
            audioSource.Play();
        }
    }
}
