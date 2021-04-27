using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControler : MonoBehaviour
{
    public AudioSource start;
    public AudioSource middle;
    // Start is called before the first frame update

    private void Start()
    {
        
    }


    bool midPlaying = false;

    // Update is called once per frame
    void Update()
    {
        
        if (!start.isPlaying&&!midPlaying)
        {
            middle.Play();
            midPlaying = true;
        }
    }

    
}
