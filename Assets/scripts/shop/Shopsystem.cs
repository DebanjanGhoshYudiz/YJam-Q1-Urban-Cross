using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopsystem : MonoBehaviour
{
    public static Shopsystem Instance;
    Getplayersprite playerspritegameobject;
    Sprite playersprite;
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
            Savesystem.Instance.cherryscore -= shopplayerdetail.Coinsrequired;
            shopplayerdetail.spritestate = Spritestate.equipped;
            Savesystem.Instance.spritestates[shopplayerdetail.childindex] = shopplayerdetail.spritestate.ToString();
            Savesystem.Instance.turnoffequippeddata(shopplayerdetail.childindex);
            shopplayerdetail.activatesprite();
            playerspritegameobject = shopplayerdetail.GetComponentInChildren<Getplayersprite>();
            playersprite = playerspritegameobject.GetComponent<Image>().sprite;
                RuntimeAnimatorController animationcontroller = shopplayerdetail.animationcontoller;
            PlayerManager.Instance.changesprite(playersprite, animationcontroller);
            Savesystem.Instance.saveplayervalues();
        }

        else
        {
            if (shopplayerdetail.spritestate == Spritestate.unlocked)
            {


                shopplayerdetail.spritestate = Spritestate.equipped;
                Savesystem.Instance.spritestates[shopplayerdetail.childindex] = shopplayerdetail.spritestate.ToString();
                Savesystem.Instance.turnoffequippeddata(shopplayerdetail.childindex);
                playerspritegameobject = shopplayerdetail.GetComponentInChildren<Getplayersprite>();
                playersprite = playerspritegameobject.GetComponent<Image>().sprite;
                RuntimeAnimatorController animationcontroller = shopplayerdetail.animationcontoller;
                PlayerManager.Instance.changesprite(playersprite, animationcontroller);
                Savesystem.Instance.saveplayervalues();
     
            }
        }

    }
    public bool buycheck(Shopplayerdetail shopplayerdetail)
    {
        float currentcherryscore = Scoringsystem.Instance.cherryscore;
        if (currentcherryscore >= shopplayerdetail.Coinsrequired)
        {
            return true;
        }
        return false;

    }
    //we will have to call savesystem from herter
}