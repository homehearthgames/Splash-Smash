using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public float waveSpeed = 0;
    public float waveAccelleration;
    public float maxWaveSpeed;
    public GameObject wave1;
    public GameObject wave2;

    public Sprite waveSp1;
    public Sprite waveSp2;
    public Sprite waveSp3;

    public Collider2D waveBC1;
    public Collider2D waveBC2;
    public Collider2D waveBC3;

    void Start()
    {
        Time.timeScale = 1;
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        waveSpeed += waveAccelleration*Time.deltaTime;
        if (waveSpeed > maxWaveSpeed)
            waveSpeed = maxWaveSpeed;

        if (wave1.transform.position.x < wave2.transform.position.x)
        {
            wave1.transform.position = new Vector3(wave1.transform.position.x - waveSpeed, wave1.transform.position.y, wave1.transform.position.z);
            wave2.transform.position = new Vector3(wave1.transform.position.x + 320, wave2.transform.position.y, wave2.transform.position.z);
        }
        else
        {
            wave2.transform.position = new Vector3(wave2.transform.position.x - waveSpeed, wave2.transform.position.y, wave2.transform.position.z);
            wave1.transform.position = new Vector3(wave2.transform.position.x + 320, wave1.transform.position.y, wave1.transform.position.z);
        }


        if (wave1.transform.position.x <= -320)
        {
            wave1.transform.position = new Vector3(wave2.transform.position.x + 320, wave1.transform.position.y, wave1.transform.position.z);
            GetNewWave(wave1);
        }

        if (wave2.transform.position.x <= -320)
        {
            wave2.transform.position = new Vector3(wave1.transform.position.x + 320, wave2.transform.position.y, wave2.transform.position.z);
            GetNewWave(wave2);
        }
    }

    void GetNewWave(GameObject wav)
    {
        int w = Random.Range(1, 4);
        if (w == 1)
        {
            wav.GetComponent<SpriteRenderer>().sprite = waveSp1;
        }
        if (w == 2)
        {
            wav.GetComponent<SpriteRenderer>().sprite = waveSp2;
        }
        if (w == 3)
        {
            wav.GetComponent<SpriteRenderer>().sprite = waveSp3;
        }
    }

}
