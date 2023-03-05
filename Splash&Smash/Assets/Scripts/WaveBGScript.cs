using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBGScript : MonoBehaviour
{
    public float waveSpeed = 0;
    public float waveAccelleration;
    public float maxWaveSpeed;
    public GameObject waveBG1;
    public GameObject waveBG2;
    public GameObject splash;
    private GameObject player;

    public int waveWidth;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.isFinished == false)
        {
            waveSpeed += waveAccelleration * Time.deltaTime;
            if (waveSpeed > maxWaveSpeed)
                waveSpeed = maxWaveSpeed;

            // scroll waves
            if (waveBG1.transform.position.x < waveBG2.transform.position.x)
            {
                waveBG1.transform.position = new Vector3(waveBG1.transform.position.x - waveSpeed, waveBG1.transform.position.y, waveBG1.transform.position.z);
                waveBG2.transform.position = new Vector3(waveBG1.transform.position.x + waveWidth, waveBG2.transform.position.y, waveBG2.transform.position.z);
            }
            else
            {
                waveBG2.transform.position = new Vector3(waveBG2.transform.position.x - waveSpeed, waveBG2.transform.position.y, waveBG2.transform.position.z);
                waveBG1.transform.position = new Vector3(waveBG2.transform.position.x + waveWidth, waveBG1.transform.position.y, waveBG1.transform.position.z);
            }


            if (waveBG1.transform.position.x <= -waveWidth)
            {
                waveBG1.transform.position = new Vector3(waveBG2.transform.position.x + waveWidth, waveBG1.transform.position.y, waveBG1.transform.position.z);
            }

            if (waveBG2.transform.position.x <= -waveWidth)
            {
                waveBG2.transform.position = new Vector3(waveBG1.transform.position.x + waveWidth, waveBG2.transform.position.y, waveBG2.transform.position.z);
            }

            // move splash wil wave bg
            if (splash != null && player.GetComponentInChildren<PlayerScript>().isJumping == false && player.GetComponentInChildren<PlayerScript>().splash1.isEmitting)
                splash.transform.position = new Vector3(splash.transform.position.x - waveSpeed / 3, splash.transform.position.y, splash.transform.position.z);

        }
    }
}
