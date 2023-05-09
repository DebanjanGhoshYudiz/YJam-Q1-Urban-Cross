using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerenderer : MonoBehaviour
{
    public LineRenderer mylinerenderer;
    public Vector3 currentposition;
    public Vector3 previouspos;
    [SerializeField] GameObject sprite;
    public float mindistance;
    //public List<LineRenderer> linerenderers;
    public EdgeCollider2D myedgecollier2d;
    public List<Vector2> positions;
    public Vector3 fromvector;
    public Vector3 tovector;
    spriteboundaries myspriteboundaries;
    public float angle;
    float timer = 0f;
    bool linemove = false;
    float perc;
    [SerializeField] GameObject player;
    [SerializeField] GameObject linerotate;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //mylinerenderer = GetComponent<LineRenderer>();
        mylinerenderer.positionCount = 1;
        mylinerenderer.SetWidth(0.1f, 0.1f);
        previouspos = transform.position;
        currentposition = new Vector3(1f, player.transform.position.y-3f,0f);
        myspriteboundaries = FindObjectOfType<spriteboundaries>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
       
        if (Input.GetMouseButtonDown(0))
        {
            currentposition= player.transform.position;
            currentposition = new Vector3(1f, currentposition.y-3f, 0f);
            mylinerenderer.SetPosition(0, currentposition);
          
        }

        if (Input.GetMouseButton(0))
        {
           

            currentposition += (player.transform.up * 0.9f * Time.deltaTime);
            currentposition = new Vector3(1f, currentposition.y, 0f);
            if (mylinerenderer.positionCount<=1)
            {
                
                mylinerenderer.positionCount++;
            }
          
            positions.Add( new Vector2(currentposition.x, currentposition.y));
            mylinerenderer.SetPosition(1, currentposition);
            myedgecollier2d.points = positions.ToArray();


          

        }
        if (Input.GetMouseButtonUp(0))
        {
            
            
            
            angle = Vector3.Angle(player.transform.up, player.transform.right);
            linemove = true;


        }
        //if (timer <= 1f && linemove)
        //{
        //    perc = Mathf.MoveTowards(0f, angle, timer);
        //    timer += Time.deltaTime;
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -perc);
        //}
        if (linemove)
        {
            perc = Mathf.MoveTowards(0f, angle, timer*200f);
            timer += Time.deltaTime;
            linerotate.transform.eulerAngles = new Vector3(0f, 0f, -perc);
        }

    }
}