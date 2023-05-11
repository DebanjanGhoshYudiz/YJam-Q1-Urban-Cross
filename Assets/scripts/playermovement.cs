using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public bool playercanmove;
    public Vector3 targetpos;
    public randomizeblock myrandomizeblock;
    public cameramove mycameramove;
    // Start is called before the first frame update
    void Start()
    {
        myrandomizeblock = FindObjectOfType<randomizeblock>();
        mycameramove = FindObjectOfType<cameramove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playercanmove)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetpos,Time.deltaTime*10f);
            if (transform.position == targetpos && (myrandomizeblock.moveblocks!=true && myrandomizeblock.moveblocks!=true && playercanmove!=false))
            {
               
                playercanmove = false;
                myrandomizeblock.moveblocks = true;
                mycameramove.cameramotion = true;
               //randomize block
            }
        }
    }
    
}
