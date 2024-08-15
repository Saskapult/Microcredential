using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripto : MonoBehaviour
{
    public Transform thingy; // Use transforms to reference objects for some reason 

    private Transform thingy0;
    private Transform thingy1;
    private Transform thingy2;
    private Transform thingy3;

    // Start is called before the first frame update 
    void Start()
    {
        thingy0 = Instantiate(thingy);
        thingy0.position = new Vector3(-3f, 0f, 0f);
        thingy1 = Instantiate(thingy);
        thingy1.position = new Vector3(-1.5f, 0f, 0f);
        thingy1.eulerAngles = new Vector3(1.0f, 2.0f, 1.0f);
        thingy1.localScale = new Vector3(1.0f, 2.0f, 1.0f);
        thingy2 = Instantiate(thingy);
        thingy2.position = new Vector3(1.5f, 0f, 0f);
        thingy3 = Instantiate(thingy);
        thingy3.position = new Vector3(3f, 0f, 0f);

        thingy1.parent = thingy0;
        thingy2.parent = thingy0;
        thingy3.parent = thingy0;
        // Must be set after setting parentss because unity 
        thingy0.eulerAngles = new Vector3(0.0f, 0.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
