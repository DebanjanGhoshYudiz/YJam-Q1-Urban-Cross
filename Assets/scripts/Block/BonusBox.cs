using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBox : MonoBehaviour
{
    [SerializeField] GameObject bonuspoint;
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
        
        //    Debug.Log("here in +1");
        //}
    }

  IEnumerator bonuspointinactive()
    {
        yield return new WaitForSeconds(1.75f);
        bonuspoint.active = false;
    }
}
