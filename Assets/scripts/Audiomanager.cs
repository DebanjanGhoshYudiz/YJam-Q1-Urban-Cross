using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [SerializeField] AudioClip[] Backgroundaudioclips;
    AudioClip backgroundclip;
    AudioSource audiosource;
    int randomint;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        randomint = Random.Range(0, Backgroundaudioclips.Length);
        audiosource.clip = Backgroundaudioclips[randomint];
        backgroundclip = audiosource.clip;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
