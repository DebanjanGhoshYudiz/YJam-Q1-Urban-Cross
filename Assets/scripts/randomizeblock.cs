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
    public bool moveblocks=false;
    // Start is called before the first frame update
    void Start()
    {

        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;
        setxminxmax();
    }

   


    // Update is called once per frame
    void Update()
    {
        
        
        //we need to change here
        //if (Input.GetMouseButtonDown(0))
        //{
        //    reshuffletransform();
        //    setminmax();
        //    blockmotion();

        //}
        if(moveblocks)
        {
            reshuffletransform();
            setminmax();
            blockmotion();
            moveblocks= moveblocksturnoff();
        }


    }

    public bool moveblocksturnoff()
    {
        
        foreach (Transform block in gameObject.transform)
        {
            if (block.transform.position != block.GetComponent<blockmove>().targetpos)
            {
                return false;
            }
        }
        return true;
    }

    public void setxminxmax()
    {
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

    public void blockmotion()
    {
        foreach (Transform block in gameObject.transform)
        {
            if (block.transform.position == xmax)
            {

                block.GetComponent<blockmove>().targetpos = xmid;
            }

            else if (block.transform.position == xmid)
            {

                block.GetComponent<blockmove>().targetpos = xmin;
            }

            else if (block.transform.position == xmin)
            {

                block.GetComponent<blockmove>().targetpos = xprev;

            }
            else if (block.transform.position == xprev)
            {
                Debug.Log("the block gameobject "+block.gameObject.name);
                randomizesize(block.gameObject);
                block.GetComponent<blockmove>().targetpos = xmax;
                block.transform.position = xmax;


            }

        }
    }

    private void reshuffletransform()
    {
        for(int i=0;i< blockpositions.Count;i++)
        {
           
            blockpositions[i].transform.position=new Vector3(blockpositions[i].transform.position.x + halfWidth, blockpositions[i].transform.position.y, blockpositions[i].transform.position.z);
        }
    }
    private void setminmax()
    {
        
        xmin = xmin + new Vector3(halfWidth, 0f,0f);
        xmid= xmid + new Vector3(halfWidth, 0f, 0f);
        xmax = xmax + new Vector3(halfWidth, 0f, 0f);
        xprev = xprev + new Vector3(halfWidth, 0f, 0f);
    }
    public void randomizesize(GameObject blockgameobject)
    {

        
        blockgameobject.transform.localScale= new Vector3(Random.Range(0.6f, 1f), blockgameobject.transform.localScale.y, blockgameobject.transform.localScale.z);
    }

}
