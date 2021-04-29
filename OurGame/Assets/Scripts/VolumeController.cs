using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource AudioSource;

    public float musicVolume = 0.5f;
    void Start()
    {
        PlayerPrefs.SetFloat("volume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
     AudioSource.volume = musicVolume;
    }
    public void updateVolume(float volume) {
        musicVolume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
}
