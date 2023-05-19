using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    Vector3 worldpos;

    // Start is called before the first frame update
    void Start()
    {

        if (gameObject.name == "block1")
        {
            worldpos = Camera.main.ViewportToWorldPoint(new Vector3(0.09f, 0.01f, 10.00f));
        }
        else if (gameObject.name == "block2")
        {
            worldpos = Camera.main.ViewportToWorldPoint(new Vector3(0.91f, 0.01f, 10.00f));
        }
        else if (gameObject.name == "block3")
        {
            worldpos = Camera.main.ViewportToWorldPoint(new Vector3(1.76f, 0.01f, 10.00f));
        }

        transform.position = worldpos;
        transform.GetChild(0).transform.localPosition = new Vector3(0f, 0.491f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
