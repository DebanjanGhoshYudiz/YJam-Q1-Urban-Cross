using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBox : MonoBehaviour
{
    [SerializeField] GameObject bonuspoint;
    [SerializeField] GameObject perfectcanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bonuspoint.active = true;
        bonuspoint.transform.position = gameObject.transform.position;
        bonuspoint.GetComponent<moveupscript>().targetpos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        bonuspoint.GetComponent<moveupscript>().ismoved = true;
        StartCoroutine(bonuspointinactive());
        perfectcanvas.GetComponent<Canvas>().enabled = true;
        perfectcanvas.active = true;
        //    Debug.Log("here in +1");
        //}
    }

    IEnumerator bonuspointinactive()
    {
        yield return new WaitForSeconds(1f);
        perfectcanvas.GetComponent<Canvas>().enabled =  false;
    }
}
