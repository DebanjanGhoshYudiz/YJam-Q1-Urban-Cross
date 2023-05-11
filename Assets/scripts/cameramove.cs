using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    [SerializeField] GameObject environment;
    [SerializeField] float xoffset;
    public Renderer bgrenderer;
    public float speed;
    float halfHeight;
    float halfWidth;
    Vector3 targetpos;
    Vector3 enivronemttargetpos;
    public bool cameramotion=false;
    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;
    }

    // Update is called once per frame
    void Update()
    {

        if (cameramotion)
        {
            targetpos= new Vector3(transform.position.x + halfWidth, transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x + halfWidth, transform.position.y, transform.position.z);
            enivronemttargetpos= new Vector3(environment.transform.position.x + halfWidth, environment.transform.position.y, environment.transform.position.z);
            environment.transform.position = enivronemttargetpos;
            bgrenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
            cameramotion = false;
        }
       
    }
}