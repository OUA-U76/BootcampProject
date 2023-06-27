using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [Header ("SERIALIZED FIELDS")]
    [SerializeField] Slider soundSlider;

    private void Start() 
    {
        if (PlayerPrefs.GetFloat("SoundVolume") != 0)
        {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
            AudioListener.volume = PlayerPrefs.GetFloat("SoundVolume");
        }
        else
        {
            soundSlider.value = 0.5f;
            AudioListener.volume = 0.5f;
        }
    }
    private void Update() 
    {
        AudioListener.volume = soundSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", soundSlider.value);
    }

}
