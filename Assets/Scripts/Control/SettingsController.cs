using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicAudioSource;

    private const string VolumePrefsKey = "MusicVolume";

    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        musicAudioSource = GameObject.Find("MusicController").GetComponent<AudioSource>();

        volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);

        float savedVolume = PlayerPrefs.GetFloat(VolumePrefsKey, 0.5f);
        volumeSlider.value = savedVolume;
        musicAudioSource.volume = savedVolume;
    }

    void OnVolumeSliderValueChanged(float value) {
        musicAudioSource.volume = value;

        PlayerPrefs.SetFloat(VolumePrefsKey, value);
        PlayerPrefs.Save(); 
    }
}
