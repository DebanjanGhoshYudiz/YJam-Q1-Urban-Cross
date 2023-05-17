using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerlockunlockdetails : MonoBehaviour
{
    //public List<string> lockunlockdetaiils;
    public List<string> savedlockunlockdetails;
    int count = 0;
    public List<Sprite> spritelist;
    // Start is called before the first frame update
    void Start()
    {
        Makespritelist();
        //savelockunlockdetails updewtiubg late
        //savedlockunlockdetails = Savesystem.Instance.spritestates;
        
    }

 

    public void assignlockunlockdetails()
    {
        savedlockunlockdetails= Savesystem.Instance.spritestates;

        if (savedlockunlockdetails.Count > 0)
        {
            
            foreach (Transform child in transform)
            {
                if (count < savedlockunlockdetails.Count)
                {
                    Shopplayerdetail spritestategameobject = child.GetComponent<Shopplayerdetail>();
                    Spritestate parsed_spritestate = (Spritestate)System.Enum.Parse(typeof(Spritestate), savedlockunlockdetails[count++]);
                  
                    if(spritestategameobject==null)
                    {
                        Debug.Log(null);
                    }
                    spritestategameobject.spritestate = parsed_spritestate;
                    spritestategameobject.activatesprite();

                }
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<Shopplayerdetail>().childindex > 0)
                {
                    Shopplayerdetail spritestategameobject = child.GetComponent<Shopplayerdetail>();
                    spritestategameobject.spritestate = Spritestate.locked;
                    spritestategameobject.activatesprite();
                    Savesystem.Instance.spritestates.Add(spritestategameobject.spritestate.ToString());


                }
                else
                {
                    
                    Shopplayerdetail spritestategameobject = child.GetComponent<Shopplayerdetail>();
                    spritestategameobject.spritestate = Spritestate.unlocked;
                    spritestategameobject.activatesprite();
                    Savesystem.Instance.spritestates.Add(spritestategameobject.spritestate.ToString());

                }
            }

            Savesystem.Instance.saveplayervalues();
        }


        }
    public Sprite Getplayersprite(int index)
    {
        for(int j=0; j<transform.childCount;j++)
        {
            if(index==j)
            {
                return spritelist[index];
            }
        }
        return null; 
    }

    private void Makespritelist()
    {

        foreach(GameObject child in transform)
        {
            GameObject childimageobject = child.GetComponent<Getplayersprite>().gameObject;
            spritelist.Add(childimageobject.GetComponent<Image>().sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
