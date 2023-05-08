using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteboundaries : MonoBehaviour
{
    SpriteRenderer myspriterenderer;
    public Vector3 threshold;
    // Start is called before the first frame update
    void Start()
    {
        myspriterenderer = GetComponent<SpriteRenderer>();
        threshold = 2*myspriterenderer.bounds.extents;
      
        //Debug.Log("the boundaries of a spriute renderer" + myspriterenderer.bounds.extents);
    }

    // Update is called once per frame
    void Update()
    {
   
        //Debug.Log("the width"+s);
    }
}
