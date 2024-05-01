using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip myAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The sounds length: " + myAudioClip.length);
        myAudioClip.LoadAudioData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
