using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] GameObject environment;
    public Renderer bgrenderer;
    public float speed;
    float halfHeight;
    float halfWidth;
    public Vector3 targetpos;
    Vector3 environmenttargetpos;
    public bool cameramotion = false;
    public static BackgroundManager Instance;
    public float xcamera;
    private void Awake()
    {
        Instance = this;
        //Camera.main.transform.position = new Vector3(0.5f,0f, -10f);
    }
    // Start is called before the first frame update
    void Start()
    {
        //targetpos = Camera.main.transform.position;
        //2.16f
        //halfHeight = Camera.main.orthographicSize;
        //halfWidth = Camera.main.aspect * halfHeight;
        targetpos = new Vector3(2.16f,0f, -10f);
        PlayerManager.Instance.Targetreachedevent += settargetpos;

    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position != targetpos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 20f);
            environment.transform.position = Vector3.MoveTowards(environment.transform.position, new Vector3(Camera.main.transform.position.x, environment.transform.position.y, environment.transform.position.z), Time.deltaTime * 20f);
            Vector2 offset = new Vector2(0.001f, 0f);
            bgrenderer.material.mainTextureOffset += offset;
        }


    }
    public void settargetpos()
    {
        Scoringsystem.Instance.Incrementgameplayscore();
        xcamera = BlockManager.Instance.diff;
        targetpos = new Vector3(transform.position.x + xcamera, transform.position.y, transform.position.z);
        environmenttargetpos = new Vector3(environment.transform.position.x + halfWidth, environment.transform.position.y, environment.transform.position.z);
    }

}