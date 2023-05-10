using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocklist : MonoBehaviour
{
    
    public List<GameObject> blocks;
    public bool blocksmove;
    public float xminworldpos;
    public float xmaxworldpos;
    public float yminworldpos;
    public float ymaxworldpos;
    // Start is called before the first frame update
    void Awake()
    {
        //for (int i = 0; i < blocks.Count; i++)
        //{
        //    if (i < blocks.Count-1)
        //    {
        //        Debug.Log("less than block count");
        //        blocks[i].SetActive(true);
        //    }
           
        //}
        xminworldpos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        yminworldpos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        xmaxworldpos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        ymaxworldpos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;
    }
    
    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x-Time.deltaTime,transform.position.y,transform.position.z);
        foreach(Transform child in gameObject.transform)
        {
            if(child.position.x<(xminworldpos- child.GetComponent<SpriteRenderer>().bounds.extents.x)-0.5f)
            {
                child.position = new Vector3(xmaxworldpos+0.5f, transform.GetChild(0).transform.position.y, transform.GetChild(0).transform.position.z);
            }
        }

        //for()
        //{

        //}
        
            
            //max scale 1 and than its less randomize
            //if out of screen change the size
            //screenpos to worldpos half screen
        
    }
}
