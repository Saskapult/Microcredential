using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformControl : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.gameObject.CompareTag("MovingPlatform")) {
            // Was contact normal within pi/3 of up? 
            if (Vector3.Dot(collisionInfo.GetContact(0).normal, Vector3.up) > 0.5f) {
                transform.parent = collisionInfo.collider.transform;
            }
        }
    }

    void OnCollisionExit(Collision collisionInfo) {
        if (collisionInfo.gameObject.CompareTag("MovingPlatform")) {
            transform.parent = null;
        }
    }
}
