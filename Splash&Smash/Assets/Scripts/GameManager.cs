using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public bool isFinished=false;

    private GameObject scoreObj;

    public static AudioSource aSource;

    public static string levelName;
    public static int score;

    public AudioMixer mixer;

    void Start()
    {
        //Time.timeScale = 1f;
        gameManager = this;
        scoreObj = GameObject.FindGameObjectWithTag("Score");
        aSource = GetComponent<AudioSource>();

        levelName = SceneManager.GetActiveScene().name;

        // set volumes from prefs
        float linearVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float logValue = Mathf.Log10(linearVolume) * 20;
        mixer.SetFloat("MusicVol", logValue);

        linearVolume = PlayerPrefs.GetFloat("SoundVolume", 0.75f);
        logValue = Mathf.Log10(linearVolume) * 20;
        mixer.SetFloat("SoundVol", logValue);

        linearVolume = PlayerPrefs.GetFloat("AnnouncerVolume", 0.75f);
        logValue = Mathf.Log10(linearVolume) * 20;
        mixer.SetFloat("AnnouncerVol", logValue);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetSpeed(float newSpeed)
    {
        var BGs=GameObject.FindObjectsByType<WaveBGScript>(FindObjectsSortMode.None);
        foreach(WaveBGScript WBS in BGs)
        {
            WBS.waveSpeed = newSpeed;
        }
    }

    public int GetScore()
    {
        return scoreObj.GetComponent<ScoreScript>().GetScore();
    }

}
