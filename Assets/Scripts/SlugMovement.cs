using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SlugMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 75.0f;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = (transform.right * horizontal + transform.forward * vertical).normalized;
        body.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);

        // var horizontal = Input.GetAxis("Horizontal");
        // transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.fixedDeltaTime, 0f);
    }
}
