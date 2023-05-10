using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public bool playercanmove;
    public Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playercanmove)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetpos,Time.deltaTime*10f);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("the collidion with player "+collision.collider.name);
    }
}
