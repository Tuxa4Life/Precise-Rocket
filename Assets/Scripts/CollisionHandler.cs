using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject forcefield;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    bool collisionState = true;

    void Update()
    {
        RespondToDebugKeys();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag) 
        {
            case "Friendly":
                break;
            case "Fuel":
                break;
            case "Finish":
                PlaySuccessSequence();
                break;
            default:
                if (collisionState)
                {
                    PlayCrashSequence();
                }
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuel"))
        {
            Destroy(other.gameObject);

            forcefield.GetComponent<MeshRenderer>().enabled = false;
            forcefield.GetComponent<SphereCollider>().enabled = false;
        }
    }

    void RespondToDebugKeys ()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionState = !collisionState;
        }
    }

    void PlaySuccessSequence ()
    {
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(NextLevel), 2f);
    }

    void PlayCrashSequence ()
    {
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(RestartLevel), 2f);
    }

    void NextLevel ()
    {
        int nextSceneID = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneID == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneID = 0;
        }
        SceneManager.LoadScene(nextSceneID);
    }

    void RestartLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
