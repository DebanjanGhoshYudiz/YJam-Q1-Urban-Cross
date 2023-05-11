using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomizeblock : MonoBehaviour
{

    /*  [SerializeField] GameObject environement;*/
    float halfHeight;
    float halfWidth;
    public GameObject refblock;
    List<randomizeblock> blocklist;
    Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {

        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;
        blocklist = FindObjectsOfType<randomizeblock>().ToList();
        for (int i = 0; i < blocklist.Count; i++)
        {
            if (blocklist[i].gameObject != gameObject)
            {
                refblock = blocklist[i].gameObject;

            }
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //we have to change the 10.5f vlue

            targetpos = new Vector3(refblock.transform.position.x + 8.75F, transform.position.y, transform.position.z);
            if (transform.position.x < (Camera.main.transform.position.x))
            {
                randomizesize();
                transform.position = targetpos;
            }
        }

    }


    public void randomizesize()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.transform.localScale = new Vector3(Random.Range(0.6f, 1f), child.transform.localScale.y, child.transform.localScale.z);
        }
    }

}
