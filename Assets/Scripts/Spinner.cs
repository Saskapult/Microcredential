using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed = 100.0f;

    void Start()
    {
        
    }

    // Run once per fixed tick, not per-frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(Time.time * speed, transform.up);
    }
}
