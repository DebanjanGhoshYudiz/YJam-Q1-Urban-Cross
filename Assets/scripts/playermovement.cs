using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public bool playercanmove;
    public Vector3 targetpos;
    cameramove cameramove;
    randomizeblock myrandomizeblock;
    GameObject collidedgameobject = null;
    public GameObject staycolliedegameobject=null;
    public bool canmove = false;
    float timer = 0f;
    Cherryinstantiate cherryinstantiate;
    bool istraight = true;
    public bool isplayerdestroyed=false;
    // Start is called before the first frame update
    void Start()
    {

        myrandomizeblock = FindObjectOfType<randomizeblock>();
        cameramove = FindObjectOfType<cameramove>();
        cherryinstantiate = FindObjectOfType<Cherryinstantiate>();
    }

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
                    //////////////////////////////////////
                    myrandomizeblock.setminmax();
                    myrandomizeblock.reshuffle();
                    cameramove.settargetpos();
                    cherryinstantiate.throwcherry();
                    playercanmove = false;
                    canmove = false;
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
        if(collision.gameObject.GetComponent<blocks>())
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