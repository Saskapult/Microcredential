using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugSpriteChanger : MonoBehaviour
{
    public Material material0;
    public Material material1;
    public float d = 0.25f;

    private int frame = 0;
    private Vector3 lastPosition;
    private Vector3 lastPositionAgain; // position last frame, used to find velocity sign

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        lastPositionAgain = lastPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - lastPosition).sqrMagnitude >= d) {
            lastPosition = transform.position;
            frame = (frame + 1) % 2;
            // Idk how to array 
            if (frame == 0) {
                var materialsCopy = GetComponent<MeshRenderer>().materials;
                materialsCopy[0] = material0;
                GetComponent<MeshRenderer>().materials = materialsCopy;
            } else {
                var materialsCopy = GetComponent<MeshRenderer>().materials;
                materialsCopy[0] = material1;
                GetComponent<MeshRenderer>().materials = materialsCopy;
            }
        }
        // Velocity rotated into camera space, find x velocity, flip based on sign
        if ((transform.position - lastPositionAgain).sqrMagnitude >= 0.001) {
            
            var v = transform.position - lastPositionAgain;
            v = Camera.main.transform.rotation * v;
            if (v.x > 0.0) {
                transform.localScale = new Vector3(1, 1, 1);
            } else {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            lastPositionAgain = transform.position;
        }
    }
}
