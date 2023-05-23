using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumescreenbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resumebuttonclick()
    {
        CanvasManager.Instance.switchscreen(ScreenType.GamePlay);
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1f;
        }
    }
}
