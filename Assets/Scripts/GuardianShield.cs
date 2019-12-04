using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianShield : MonoBehaviour
{
    public float deathTime;

    void FixedUpdate()
    {
        deathTime -= Time.deltaTime;
        if (deathTime < 0)
        {
            Object.Destroy(this);
        }
    }
}
