using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopsystem : MonoBehaviour
{
    public static Shopsystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    //first we have to retrieve the list from savesystem
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spritebuy(Shopplayerdetail shopplayerdetail)
    {
     
        if (buycheck(shopplayerdetail) && shopplayerdetail.spritestate == Spritestate.locked)
        {
            
            Scoringsystem.Instance.cherryscore -= shopplayerdetail.Coinsrequired;
            Savesystem.Instance.cherryscore-= shopplayerdetail.Coinsrequired;
            shopplayerdetail.spritestate = Spritestate.unlocked;
            Savesystem.Instance.spritestates[shopplayerdetail.childindex] = shopplayerdetail.spritestate.ToString();
            Savesystem.Instance.saveplayervalues();
             shopplayerdetail.activatesprite();
            Getplayersprite playerspritegameobject = shopplayerdetail.GetComponentInChildren<Getplayersprite>();
            Sprite playersprite = playerspritegameobject.GetComponent<Image>().sprite;
            PlayerManager.Instance.changesprite(playersprite);
            //also one condition to save the sprite



        }
       
        else
        {
            if (shopplayerdetail.spritestate == Spritestate.unlocked)
            {
                Getplayersprite playerspritegameobject = shopplayerdetail.GetComponentInChildren<Getplayersprite>();
                Sprite playersprite = playerspritegameobject.GetComponent<Image>().sprite;
                PlayerManager.Instance.changesprite(playersprite);
                float index = shopplayerdetail.childindex;
            }
        }
      
    }
    public bool buycheck(Shopplayerdetail shopplayerdetail)
    {
        float currentcherryscore = Scoringsystem.Instance.cherryscore;
        if(currentcherryscore>= shopplayerdetail.Coinsrequired)
        {
            return true;
        }
        return false;

    }
    //we will have to call savesystem from herter
}
