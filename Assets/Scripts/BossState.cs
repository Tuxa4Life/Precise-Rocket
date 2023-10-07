using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    public float bossHp = 5f;

    void Update()
    {
        if (bossHp == 0f)
        {
            Destroy(gameObject);
        }
    }
}
