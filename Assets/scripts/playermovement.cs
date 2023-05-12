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
    public bool canmove = false;
    float timer = 0f;
    Cherryinstantiate cherryinstantiate;
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
        if (playercanmove)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 2f);
            if (transform.position == targetpos && canmove)
            {


                myrandomizeblock.setminmax();
                myrandomizeblock.reshuffle();
                cameramove.settargetpos();
                cherryinstantiate.throwcherry();
                //cherryinstantiate.
                playercanmove = false;
                canmove = false;
                //FindObjectOfType<blocklist>().blocksmove = true;
            }

        }
        //ifplayer can move than only mirror the positin on mousebutton down
        if (Input.GetMouseButtonDown(0))
        {
            if (playercanmove)
            {
                if (transform.localScale.y == 0.5)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -0.5f, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
                }
                else if (transform.localScale.y == -0.5)
                {

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
       //if the player collides and scale is backwards stop the game
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        
        if (collision.gameObject != null && playercanmove == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(collision.collider.bounds.max.x - 0.3f, transform.position.y, transform.position.z), timer * 2f);
            timer += Time.deltaTime;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        canmove = false;

    }

}