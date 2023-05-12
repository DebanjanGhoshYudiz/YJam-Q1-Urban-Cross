using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherryinstantiate : MonoBehaviour
{
    [SerializeField] GameObject cherry;
    GameObject cherrygameobject;
    float y;
    Vector3 xmin;
    Vector3 xmax;
    float randnumber;
    float xmaxworldpos;
    randomizeblock myrandomizeblock;
    // Start is called before the first frame update
    void Start()
    {
        cherrygameobject = Instantiate(cherry,Vector3.zero,Quaternion.identity);
        cherrygameobject.SetActive(false);
        xmaxworldpos = Camera.main.ViewportToWorldPoint(new Vector3(1,0)).x;
        myrandomizeblock = FindObjectOfType<randomizeblock>();

    }

    // Update is called once per frame
    void Update()
    {

        //if()
        //{

        //}
        
    }

    [System.Obsolete]
    public void throwcherry()
    {

        //throw a condition if cherry is already there
        xmin = myrandomizeblock.xmid;
        xmax = myrandomizeblock.xmax;
        Debug.Log(cherrygameobject.active);
        randnumber = Random.Range(1, 5);
        if (randnumber==1 || randnumber==2 && cherrygameobject.active==false)
        {
           
            cherrygameobject.SetActive(true);
            if(randnumber==1)
            {
                y = -2.5f;
            }
            else
            if(randnumber == 2)
            {
                y = -1.87f;
            }
            cherrygameobject.transform.position = new Vector3(Random.Range(xmin.x+2f,xmax.x-3f), y, 0f);
        }
    }

}
