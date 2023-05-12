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
    // Start is called before the first frame update
    void Start()
    {
        myrandomizeblock = FindObjectOfType<randomizeblock>();
        cameramove = FindObjectOfType<cameramove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercanmove)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 2f);
            if (transform.position == targetpos && canmove)
            {


                myrandomizeblock.setminmax();
                myrandomizeblock.reshuffle();
                cameramove.settargetpos();
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

                if (transform.localScale.y == 1f)
                {
                    Debug.Log("localscale " + 1f);
                    transform.localScale = new Vector3(transform.localScale.x, -1f, transform.localScale.z);
                    //-1.55f;
                    transform.position = new Vector3(transform.position.x, -1.55f, transform.position.z);
                }
                else if (transform.localScale.y == -1f)
                {
                    Debug.Log("localscale " + -1f);
                    //-0.3049555f
                    transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, -0.3049555f, transform.position.z);
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