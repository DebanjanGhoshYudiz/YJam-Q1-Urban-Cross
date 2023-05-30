using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundrandomize : MonoBehaviour
{
    public List<Material> environments;
    MeshRenderer meshrenderer;
    public int environmentcount;
    // Start is called before the first frame update
    void Start()
    {

        environementchange();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void environementchange()
    {
        environmentcount = Random.Range(0, environments.Count);
        meshrenderer = GetComponent<MeshRenderer>();

        meshrenderer.material = environments[environmentcount];

    }
}
