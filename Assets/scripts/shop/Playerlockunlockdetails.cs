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
        /* Makespritelist();*/
        //savelockunlockdetails updewtiubg late
        //savedlockunlockdetails = Savesystem.Instance.spritestates;

    }



    public void assignlockunlockdetails()
    {
        count = 0;
        savedlockunlockdetails = Savesystem.Instance.spritestates;

        if (savedlockunlockdetails.Count > 0)
        {

            foreach (Transform child in transform)
            {




                //0th index
                if (count < savedlockunlockdetails.Count)
                {
                    Shopplayerdetail spritestategameobject = child.GetComponent<Shopplayerdetail>();
                    Spritestate parsed_spritestate = (Spritestate)System.Enum.Parse(typeof(Spritestate), savedlockunlockdetails[count++]);
                    spritestategameobject.spritestate = parsed_spritestate;
                    spritestategameobject.activatesprite();
                    if (spritestategameobject.spritestate == Spritestate.equipped)
                    {

                        Getplayersprite playerspritegameobject = spritestategameobject.GetComponentInChildren<Getplayersprite>();
                        Sprite playersprite = playerspritegameobject.GetComponent<Image>().sprite;
                        RuntimeAnimatorController spriteanimatiocontroller = spritestategameobject.animationcontoller;
                        //PlayerManager.Instance.changesprite(playersprite, spriteanimatiocontroller);
                        //change the animation sprite here
                    }
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
                    Getplayersprite playerspritegameobject = spritestategameobject.GetComponentInChildren<Getplayersprite>();
                    Sprite playersprite = playerspritegameobject.GetComponent<Image>().sprite;
                    RuntimeAnimatorController spriteanimatiocontroller = spritestategameobject.animationcontoller;
                    //PlayerManager.Instance.changesprite(playersprite, spriteanimatiocontroller);
                    //in children the sprite is there;

                }
            }

            Savesystem.Instance.saveplayervalues();
        }


    }
}
 
   
