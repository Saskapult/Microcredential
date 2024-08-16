using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SlugMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 75.0f;
    public float jumpForce = 5.0f;

    private bool jumpTime = false;

    private Rigidbody body;
    private Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
    }

    void Update() {
        if (onGround() && Input.GetButtonDown("Jump")) {
            jumpTime = true;
        }
    }

    bool onGround() {
        return Physics.OverlapSphere(transform.position, 0.05f, ~LayerMask.GetMask("Player")).Length != 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = (transform.right * horizontal + transform.forward * vertical).normalized;
        body.MovePosition(transform.position + camera.rotation * dir * speed * Time.fixedDeltaTime);

        if (jumpTime) {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpTime = false;
        }
    }
}
