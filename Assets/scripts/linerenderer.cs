using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerenderer : MonoBehaviour
{
    public LineRenderer mylinerenderer;
    public Vector3 currentposition;
    public float mindistance;
    public EdgeCollider2D myedgecollier2d;
    public List<Vector2> positions;
    public float angle;
    float timer = 0f;
    bool linerotate = false;
    float percmoved;
    [SerializeField] GameObject player;
    public float yminsprite;
    playermovement myplayermovement;
    public Vector3 targetpos;
    public float length;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        myplayermovement = FindObjectOfType<playermovement>();
        mylinerenderer.SetWidth(0.1f, 0.1f);
        yminsprite = player.GetComponent<SpriteRenderer>().bounds.min.y;
        currentposition = Vector3.zero;
        linerotate = false;
    }

    // Update is called once per frame
    void Update()
    {

        //otherwise tyhe line rendere will move with player
        if (!linerotate && !myplayermovement.playercanmove)
        {
            
                transform.position = new Vector3(player.transform.position.x + 0.5f, yminsprite, 0f);
            
            if (Input.GetMouseButtonDown(0))
            {
                currentposition = Vector3.zero;
                mylinerenderer.SetPosition(0, currentposition);
            }




            if (Input.GetMouseButton(0))
            {
                length = mylinerenderer.GetPosition(1).y - mylinerenderer.GetPosition(0).y;
                if (length <= 3f)
                {
                    currentposition += (player.transform.up * 0.9f * Time.deltaTime);
                    currentposition = new Vector3(0f, currentposition.y, 0f);
                    if (mylinerenderer.positionCount <= 1)
                    {

                        mylinerenderer.positionCount++;
                    }

                    positions.Add(new Vector2(currentposition.x, currentposition.y));
                    mylinerenderer.SetPosition(1, currentposition);
                    myedgecollier2d.points = positions.ToArray();
                }
                else
                {

                    linerotate = true;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                linerotate = true;
            }


        }

            if (linerotate)
            {
                angle = Vector3.Angle(player.transform.up, player.transform.right);
                percmoved = Mathf.MoveTowards(0f, angle, timer * 200f);
                timer += Time.deltaTime;
                mylinerenderer.transform.eulerAngles = new Vector3(0f, 0f, -percmoved);

                if (mylinerenderer.transform.eulerAngles.z == 270f)
                {
                    myplayermovement.playercanmove = true;
                    linerotate = false;
                    myplayermovement.targetpos = new Vector3(transform.position.x + positions[positions.Count - 1].y, player.transform.position.y, player.transform.position.z);
                }

            }
        }
}