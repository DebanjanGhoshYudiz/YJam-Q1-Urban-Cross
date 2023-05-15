using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool playercanmove=false;
    public Vector3 targetpos;
    GameObject collidedgameobject = null;
    public GameObject staycolliedegameobject=null;
    public bool canmove = false;
    float timer = 0f;
    bool istraight = true;
    public bool isplayerdestroyed=false;
    public event Action Targetreachedevent;
    public static PlayerManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

       
    }


//    in line renderer add +0.25f to the target posremove the mid point script from playerin physics 2d matrix disable collision between line renderer layer and playersmall the size of boxcollider in line redndereradd boxcollider on both mid and line renderer and add dynamic rigidbodychange on collider to ontrigger in cherry
//for ui change camera x value to 4 and size 4, otherwise 6
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.zero;
        if (playercanmove && !isplayerdestroyed)
        {
            targetpos = new Vector3(targetpos.x, transform.position.y, targetpos.z);
            transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 2f);
            if (transform.position == targetpos )
            {

                if (canmove)
                {
                    if (Targetreachedevent != null)
                    {
                        Targetreachedevent();
                        playercanmove = false;
                        canmove = false;
                    }
                        //////////////////////////////////////
                    //    myrandomizeblock.setminmax();
                    //myrandomizeblock.reshuffle();
                    //cameramove.settargetpos();
                    //cherryinstantiate.throwcherry();
                    //playercanmove = false;
                    //canmove = false;
                    //////////////////////////////////////
                }
                if (collidedgameobject == null)
                {
                    isplayerdestroyed = true;
                }
            }
            
          
        }
        if(isplayerdestroyed)
        {
            Vector3 targetpos;
            targetpos = transform.position - Vector3.up * 20f;
            transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 10f);

        }
        //ifplayer can move than only mirror the positin on mousebutton down
        if (Input.GetMouseButtonDown(0))
        {
            if (playercanmove && !isplayerdestroyed)
            {
                if (transform.localScale.y == 0.5)
                {
                    istraight = false;
                    transform.localScale = new Vector3(transform.localScale.x, -0.5f, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
                }
                else if (transform.localScale.y == -0.5)
                {
                    istraight = true;
                    transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, -1.87f, transform.position.z);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject != collidedgameobject)
        {
            collidedgameobject = collision.collider.gameObject;
            canmove = true;
           
        }
        if(collision.gameObject.GetComponent<Blocks>())
        {
            if(!istraight)
            {
                isplayerdestroyed = true;
                playercanmove = false;
                //playerdestroy();
            }
        }

       //if the player collides and scale is backwards stop the game
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        //staycolliedegameobject = collision.collider.gameObject;
        if (collision.gameObject != null && playercanmove == false && !isplayerdestroyed)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(collision.collider.bounds.max.x - 0.3f, transform.position.y, transform.position.z), timer * 2f);
            timer += Time.deltaTime;
        }
        //else
        //{
        //    staycolliedegameobject = null;
        //}

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collidedgameobject = null;
         canmove = false;
    }
    //public void playerdestroy()
    //{
       
    //    Vector3 targetpos;
    //    targetpos = transform.position - Vector3.up * 20f;
    //    transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime*10f);

    //}

}