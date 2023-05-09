using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerenderer : MonoBehaviour
{
    LineRenderer mylinerenderer;
    public Vector3 currentposition;
    public Vector3 previouspos;
    [SerializeField] GameObject sprite;
    public float mindistance;
    public List<LineRenderer> linerenderers;
    public EdgeCollider2D myedgecollier2d;
    public List<Vector2> positions;
    public Vector3 fromvector;
    public Vector3 tovector;
    spriteboundaries myspriteboundaries;
    public float angle;
    float timer = 0f;
    bool linemove = false;
    float perc;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        mylinerenderer = GetComponent<LineRenderer>();
        mylinerenderer.positionCount = 1;
        mylinerenderer.SetWidth(0.1f, 0.1f);
        previouspos = transform.position;
        currentposition = new Vector3(0, 0, 0);
        myspriteboundaries = FindObjectOfType<spriteboundaries>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            ////linecount 0 differtent and more than that its different

            currentposition += (transform.up * 0.9f * Time.deltaTime);
            //sprite.transform.position = currentposition;
            positions.Add(new Vector2(currentposition.x, currentposition.y));
            mylinerenderer.positionCount++;
            mylinerenderer.SetPosition(mylinerenderer.positionCount - 1, currentposition);

            myedgecollier2d.points = positions.ToArray();




        }
        if (Input.GetMouseButtonUp(0))
        {
            linemove = true;
            fromvector = new Vector3(currentposition.x, currentposition.y, 0f) - Vector3.zero;
            tovector = myspriteboundaries.differencevector;
            angle = Vector3.Angle(fromvector, tovector);


        }
        if (timer <= 1f && linemove)
        {
            perc = Mathf.Lerp(0f, angle, timer);
            timer += Time.deltaTime;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -perc);
        }

    }
}