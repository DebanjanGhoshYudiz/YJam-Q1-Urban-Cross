using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoringsystem : MonoBehaviour
{
    public static Scoringsystem Instance;
    public int cherryscore
    {
        get;
        set;
    }
    public int gameplayscore
    {
        get;
        set;
    }
    public TextMeshProUGUI Cherrytext;
    public TextMeshProUGUI Gameplayscoretext;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Incrementcherryscore()
    {
        cherryscore += 1;
        Cherrytext.text = cherryscore.ToString();
    }
    public void Incrementgameplayscore()
    {
        gameplayscore += 1;
        Gameplayscoretext.text = gameplayscore.ToString();
    }
    public void gameplayscoreset()
    {
        gameplayscore = 0;
        Gameplayscoretext.text = gameplayscore.ToString();
    }
}