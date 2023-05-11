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
    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            transform.position = new Vector3(transform.position.x + halfWidth + 0.3f, transform.position.y, transform.position.z);
            environment.transform.position = new Vector3(environment.transform.position.x + halfWidth + 0.3f, environment.transform.position.y, environment.transform.position.z);
            bgrenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);

        }
    }
}