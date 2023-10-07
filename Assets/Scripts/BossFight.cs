using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] Canvas canvas;

    void Start()
    {
        canvas.enabled = false;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            boss.GetComponent<BossState>().bossHp -= 1;

            other.GetComponent<BoxCollider>().enabled = false;
            Destroy(other.gameObject);
        } else if (other.CompareTag("CanvaTrigger"))
        {
            other.GetComponent<BoxCollider>().enabled = false;
            canvas.enabled = !canvas.enabled;
        }
    }

}
