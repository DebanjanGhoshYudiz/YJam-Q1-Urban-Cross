using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool playercanmove=false;
    public Vector3 targetpos;
    public GameObject collidedgameobject = null;
    public bool platformpresent = false;
    float timer = 0f;
    public bool istraight = true;
    public bool isplayerdestroyed=false;
    public event Action Targetreachedevent;
    public static PlayerManager Instance;
    public bool delay=false;
    LineRendererManager lineRendererManager;
    Animator animator;
    Vector3 viewpos;
    float xthreshold;
    private void Awake()
    {
        viewpos = new Vector3(0.1255555f,0.313f,10f);
        Application.targetFrameRate = 500;
        Instance = this;
        animator = GetComponent<Animator>();
        transform.position = Camera.main.ViewportToWorldPoint(viewpos);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        lineRendererManager = FindObjectOfType<LineRendererManager>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        //out of coillision exit platformpresent is null

        transform.eulerAngles = Vector3.zero;
       
        if (playercanmove && !isplayerdestroyed)
        {
            //the problem lies somewgere ghere
            animator.SetBool("Run",true);
            targetpos = new Vector3(targetpos.x, transform.position.y, targetpos.z);
            movetowardstarget(transform.position, targetpos);
            if (transform.position == targetpos )
            {
                if (platformpresent)
                {
                    if (Targetreachedevent != null)
                    {
                        Targetreachedevent();
                       
                        playercanmove = false;
                        platformpresent = false;
                    }
                       
                }
                if (collidedgameobject == null)
                {

                    isplayerdestroyed = true;

                }
                else
                {
                  
                    if (transform.position.x > xthreshold)
                    {
                        isplayerdestroyed = true;
                    }
                }
           
            }
            
        }
        if(isplayerdestroyed)
        {
            animator.SetBool("Run", false);
            if (lineRendererManager.length <= 5f)
            {
                lineRendererManager.linerotatereverse = true;
            }
            else
            {
                lineRendererManager.linerotatereverse = false;
            }
            Vector3 targetpos;
            Savesystem.Instance.saveplayervalues();
            Scoringsystem.Instance.highscore();
            targetpos = transform.position - Vector3.up * 20f;
            movetowardstarget(transform.position, targetpos);
            if (delay == false)
            {
                delay = true;
                StartCoroutine(Gameoverscreen());
            }
        }
        else
        {
            
            delay =false;
        }


        ////below code for player goes upside down and up
        if (Input.GetMouseButtonDown(0))
        {
            if (playercanmove && !isplayerdestroyed)
            {
                if (transform.localScale.y == 0.5)
                {
                    istraight = false;
                    transform.localScale = new Vector3(transform.localScale.x, -0.5f, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, -2.45f, transform.position.z);
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

    
    IEnumerator Gameoverscreen()
    {
      
        yield return new WaitForSeconds(2f);
        if (isplayerdestroyed)
        {
            CanvasManager.Instance.Gameover();
        }
        delay = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject != collidedgameobject)
        {
            
            collidedgameobject = collision.collider.gameObject;
            xthreshold = collision.collider.bounds.max.x;
            platformpresent = true;
           
        }
        //for player death
        if(collision.gameObject.GetComponent<Blocks>())
        {
            if(!istraight)
            {
               
                istraight = true;
                isplayerdestroyed = true;
                playercanmove = false;
        
            }
        }

      
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject != null && playercanmove == false && !isplayerdestroyed)
        {
            targetpos = new Vector3(collision.collider.bounds.max.x - 0.3f, transform.position.y, transform.position.z);
            movetowardstarget(transform.position, targetpos);
            animator.SetBool("Run", false);
        }
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
        if (platformpresent == true)
        {
            collidedgameobject = null;
            platformpresent = false;
        }
    }
    
    public void movetowardstarget(Vector3 presentpos,Vector3 targetpos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 5f);
    }
    public void changesprite(Sprite sprite, RuntimeAnimatorController spriteanimationcontroller)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = spriteanimationcontroller;
    }

    

}
