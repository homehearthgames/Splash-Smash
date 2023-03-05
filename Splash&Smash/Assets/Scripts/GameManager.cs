using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public bool isFinished=false;

    private GameObject scoreObj;

    public static AudioSource aSource;

    public static string levelName;
    public static int score;

    void Start()
    {
        //Time.timeScale = 1f;
        gameManager = this;
        scoreObj = GameObject.FindGameObjectWithTag("Score");
        aSource = GetComponent<AudioSource>();

        levelName = SceneManager.GetActiveScene().name;
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
