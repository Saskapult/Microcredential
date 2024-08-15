using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    public Vector3 moveAmount = Vector3.zero;
    public float smoothTime = 0.2f;
    public bool cyclic = true;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + moveAmount;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        if (cyclic && (transform.position - targetPosition).sqrMagnitude < 0.01f) {
            (startPosition, targetPosition) = (targetPosition, startPosition);
        }
    }
}
