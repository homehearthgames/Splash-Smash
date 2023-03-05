using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceHandler : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundEffectSource;
    public AudioSource announcerSource;


    [Header("SFXClips")]
    public AudioClip buttonClickSoundEffect;

    [Header("AnnouncerClips")]
    public AudioClip gameStartAnnoucement;

    [Header("MusicClips")]
    public AudioClip surfsideCityMusic;
    public AudioClip jumanjiJungleMusic;
    public AudioClip santoriniSunsetMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
