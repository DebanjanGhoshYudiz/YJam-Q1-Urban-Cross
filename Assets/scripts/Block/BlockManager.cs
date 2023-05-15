using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    /*  [SerializeField] GameObject environement;*/
    float halfHeight;
    float halfWidth;
    Vector3 targetpos;
    public List<Transform> blockpositions;
    public Vector3 xmin
    {
        get;
        private set;
    }
    public Vector3 xmid
    {
        get;
        private set;
    }
    
    public Vector3 xmax
    {
        get;
        private set;
    }
    Vector3 xprev;
    public static BlockManager Instance;
    private void Awake()
    {
        Instance = this;
        PlayerManager.Instance.Targetreachedevent += setminmax;
        PlayerManager.Instance.Targetreachedevent += reshuffle;
    }
    //[SerializeField] GameObject testobject;
    // Start is called before the first frame update
    void Start()
    {

        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;
      

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


        
        //float xthreshold = xmid.x - xmin.x;
        xmin = xmin + new Vector3(halfWidth, 0f, 0f);
        xmid = xmid + new Vector3(halfWidth, 0f, 0f);
        //xmax = xmax + new Vector3(halfWidth, 0f, 0f);
        xmax= xmid + new Vector3(Random.Range(xmid.x+2f,halfWidth), 0f, 0f);
        //xmax will be greter tghan xwitdh
        //xmax = new Vector3(Camera.main.transform.position.x + 2*halfWidth+Random.Range(3F,6F), xmax.y, xmax.z);
        xprev = xprev + new Vector3(halfWidth, 0f, 0f);
    }

    public void reshuffle()
    {
        foreach (Transform block in gameObject.transform)
        {
            if (block.transform.position.x <= xprev.x)
            {
                randomizesize(block.gameObject);
                //we can change in xmax
                block.transform.position = xmax;

            }
        }
    }
}

