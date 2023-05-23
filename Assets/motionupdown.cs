using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionupdown : MonoBehaviour
{
    float timer = 0;
    float tp=2f;
    float f;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        f = 1 / tp;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       
         value = Mathf.Sin(2*Mathf.PI* (f) *timer);
        transform.position = new Vector3(transform.position.x,transform.position.y+value, transform.position.z);
    }
}
