using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    void Start()
    {
        Time.timeScale = 1f;
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSpeedToZero()
    {
        var BGs=GameObject.FindObjectsByType<WaveBGScript>(FindObjectsSortMode.None);
        foreach(WaveBGScript WBS in BGs)
        {
            WBS.waveSpeed = 0;
        }
    }

}
