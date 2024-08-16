using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shady : MonoBehaviour
{
    public Color color = Color.red;
    public float checkDistance = 1.0f;

    private Transform player;
    private Renderer rendy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rendy = GetComponent<Renderer>();
        checkDistance = Mathf.Pow(checkDistance, 2.0f);

        StartCoroutine("DoCheck");
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     Check()
    // }

    void Check() {
        if ((player.position - transform.position).sqrMagnitude < checkDistance) {
            rendy.material.SetColor("_Color", Color.Lerp(color, Color.white, (player.position - transform.position).sqrMagnitude / checkDistance));
        } else {
            rendy.material.SetColor("_Color", Color.white);
        }
    }

    // What in the hell is this? 
    // It makes things non-blocking 
    IEnumerator DoCheck() {
        for (; ; ) {
            Check();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
