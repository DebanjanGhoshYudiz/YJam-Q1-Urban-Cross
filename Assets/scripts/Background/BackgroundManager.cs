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
    Vector3 targetpos;
    Vector3 environmenttargetpos;
    public bool cameramotion = false;
    public static BackgroundManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        targetpos = Camera.main.transform.position;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;
        PlayerManager.Instance.Targetreachedevent += settargetpos;
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position != targetpos)
        {

            //distance between xmid and xmax
            //xmid -xmax is max threshold
            //float xmove = xmax - xmid;
            transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 20f);
            environment.transform.position = Vector3.MoveTowards(environment.transform.position, environmenttargetpos, Time.deltaTime * 20f);
        }


    }
    public void settargetpos()
    {
        //problerm may arise later
        Scoringsystem.Instance.Incrementgameplayscore();
        Vector3 minpos = BlockManager.Instance.xmin;
        Vector3 midpos = BlockManager.Instance.xmid;
        Vector3 maxpos = BlockManager.Instance.xmax;
        float xmin = maxpos.x - midpos.x;
     
        //float xmax = xmin + 1.5f;
        //float xrand = UnityEngine.Random.Range(xmin, xmax);
        targetpos = new Vector3(transform.position.x + xmin, transform.position.y, transform.position.z);
        environmenttargetpos = new Vector3(environment.transform.position.x + xmin, environment.transform.position.y, environment.transform.position.z);
    }

}