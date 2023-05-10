using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundscroller : MonoBehaviour
{
    public Renderer bgrenderer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        bgrenderer.material.mainTextureOffset += new Vector2(speed*Time.deltaTime,0f);
    }
}
