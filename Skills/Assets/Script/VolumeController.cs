using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource audio;
    public Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Camera").GetComponent<AudioSource>();
        musicSlider.value = PlayerPrefs.GetFloat("CurVol");
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = musicSlider.value;
        PlayerPrefs.SetFloat("CurVol", audio.volume);
        PlayerPrefs.Save();
    }
   
}
