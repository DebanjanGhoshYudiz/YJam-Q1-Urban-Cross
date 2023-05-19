using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveupscript : MonoBehaviour
{
    public bool ismoved;
    public Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ismoved)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetpos,Time.deltaTime*2f);
        }
        if(transform.position==targetpos)
        {
            ismoved = false;
            gameObject.active = false;
        }
    }
}
