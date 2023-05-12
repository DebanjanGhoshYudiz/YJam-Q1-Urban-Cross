using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomizeblock : MonoBehaviour
{

    /*  [SerializeField] GameObject environement;*/
    float halfHeight;
    float halfWidth;
    public GameObject refblock;
    List<randomizeblock> blocklist;
    Vector3 targetpos;
    public List<Transform> blockpositions;
    public Vector3 xmin;
    public Vector3 xmid;
    public Vector3 xmax;
    public Vector3 xprev;
    [SerializeField] GameObject testobject;
    // Start is called before the first frame update
    void Start()
    {

        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;
        //blocklist = FindObjectsOfType<randomizeblock>().ToList();
        //for (int i = 0; i < blocklist.Count; i++)
        //{
        //    if (blocklist[i].gameObject != gameObject)
        //    {
        //        refblock = blocklist[i].gameObject;

        //    }
        //}


        foreach (Transform child in gameObject.transform)
        {

            if (child.transform.position.x < Camera.main.transform.position.x && (child.transform.position.x > (Camera.main.transform.position.x - halfWidth)))
            {
                xmin = child.transform.position;
            }
            else
            if ((child.transform.position.x > Camera.main.transform.position.x) && (child.transform.position.x < (Camera.main.transform.position.x + halfWidth)))
            {
                xmid = child.transform.position;
            }
            else
            if (child.transform.position.x > (Camera.main.transform.position.x + halfWidth))
            {
                xmax = child.transform.position;
            }
            else
            if (child.transform.position.x < (Camera.main.transform.position.x - halfWidth))
            {
                xprev = child.transform.position;
            }

            blockpositions.Add(child.transform);
        }
    }



    // Update is called once per frame
    void Update()
    {


    }


    public void randomizesize(GameObject blockgameobject)
    {

        blockgameobject.transform.localScale = new Vector3(Random.Range(0.3f, 1f), blockgameobject.transform.localScale.y, blockgameobject.transform.localScale.z);
    }
    public void setminmax()
    {

        xmin = xmin + new Vector3(halfWidth, 0f, 0f);
        xmid = xmid + new Vector3(halfWidth, 0f, 0f);
        xmax = xmax + new Vector3(halfWidth, 0f, 0f);
        xprev = xprev + new Vector3(halfWidth, 0f, 0f);
    }

    public void reshuffle()
    {
        foreach (Transform block in gameObject.transform)
        {
            if (block.transform.position.x <= xprev.x)
            {
                randomizesize(block.gameObject);
                block.transform.position = xmax;
            }
        }
    }
}

