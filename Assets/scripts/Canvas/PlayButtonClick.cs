using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playbuttonclick()
    {
        CanvasManager.Instance.GamePlay();
        Time.timeScale = 1f;
        //BackgroundManager.Instance.gameplaycamerasetting();

    }
}
