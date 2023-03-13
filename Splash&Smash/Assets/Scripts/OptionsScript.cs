using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public GameObject sliderSound;
    public GameObject sliderMusic;
    public GameObject sliderAnnouncer;

    void Start()
    {            
        // load volumes slider settings from playerprefs
        sliderMusic.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sliderSound.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundVolume", 0.75f);
        sliderAnnouncer.GetComponent<Slider>().value = PlayerPrefs.GetFloat("AnnouncerVolume", 0.75f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume()
    {
        float linearVolume = sliderMusic.GetComponent<Slider>().value;
        float logValue = Mathf.Log10(linearVolume) * 20;
        sliderMusic.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MusicVol", logValue);
        PlayerPrefs.SetFloat("MusicVolume", sliderMusic.GetComponent<Slider>().value);
    }

    public void SetSoundVolume()
    {
        float linearVolume = sliderSound.GetComponent<Slider>().value;
        float logValue = Mathf.Log10(linearVolume) * 20;
        sliderSound.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("SoundVol", logValue);
        PlayerPrefs.SetFloat("SoundVolume", sliderSound.GetComponent<Slider>().value);
    }

    public void SetAnnouncerVolume()
    {
        float linearVolume = sliderAnnouncer.GetComponent<Slider>().value;
        float logValue = Mathf.Log10(linearVolume) * 20;
        sliderAnnouncer.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("AnnouncerVol", logValue);
        PlayerPrefs.SetFloat("AnnouncerVolume", sliderMusic.GetComponent<Slider>().value);
    }

}
