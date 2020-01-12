using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLooper : MonoBehaviour
{

    AudioSource audio;
    public List<AudioClip> clips;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = clips[Random.Range(0, clips.Count)];
    }

    // Update is called once per frame
    void Update()
    {
       if(!audio.isPlaying)
        {
            audio.clip = clips[Random.Range(0, clips.Count)];
            audio.Play();
        }
       
    }
}
