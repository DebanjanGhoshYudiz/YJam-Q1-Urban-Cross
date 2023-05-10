using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmove : MonoBehaviour
{
    public float xminworldpos;
    public float xmaxworldpos;
    public float yminworldpos;
    public float ymaxworldpos;
    public float xmidworldpos;
    public Vector3 targetpos;
    bool canstartmove;
    // Start is called before the first frame update
    void Start()
    {
        xminworldpos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        yminworldpos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        xmaxworldpos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        ymaxworldpos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;
        xmidworldpos = (xminworldpos + xmaxworldpos) / 2;
        targetpos = new Vector3(Random.Range(xmidworldpos, xmaxworldpos), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {





        if(Input.GetMouseButtonDown(0))
        {
            //if (transform.position.x > xmaxworldpos)
            //{
            //    Debug.Log("here in greater than maxworldpos");
            //    targetpos = new Vector3(Random.Range(xmidworldpos, xmaxworldpos), transform.position.y, transform.position.z);
            //}
            //else if ((transform.position.x < xmaxworldpos) && (transform.position.x > xmidworldpos))
            //{
            //    Debug.Log("here in mid worlpdpos");
            //    targetpos = new Vector3(Random.Range(xminworldpos, xmidworldpos), transform.position.y, transform.position.z);
            //}
            //else if (transform.position.x <= xmidworldpos)
            //{
            //    Debug.Log("here less than xmidpos");
            //    targetpos = new Vector3(xminworldpos - 0.1f, transform.position.y, transform.position.z);
            //}
        }

    }
    
}
