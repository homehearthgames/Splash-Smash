using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject wave1;
    public GameObject wave2;
    public GameObject wave3;
    public GameObject wave4;
    public GameObject wave5;
    public GameObject wave6;
    public GameObject wave7;
    public GameObject wave8;

    private Vector3 wave1Start;
    private Vector3 wave2Start;
    private Vector3 wave3Start;
    private Vector3 wave4Start;
    private Vector3 wave5Start;
    private Vector3 wave6Start;
    private Vector3 wave7Start;
    private Vector3 wave8Start;

    public float wave1Speed;
    public float wave2Speed;
    public float wave3Speed;
    public float wave4Speed;
    public float wave5Speed;
    public float wave6Speed;
    public float wave7Speed;
    public float wave8Speed;

    public float waveSpeedMultiplier;

    private bool isWaveStarted = false;

    public float waveFreq;
    private float startWaveTime;
    private float waveTime=2.5f; // how many seconds it takes the wave to 

    public WaveBGScript mainWBS;

    // Start is called before the first frame update
    void Start()
    {
        wave1Start = wave1.transform.position;
        wave2Start = wave2.transform.position;
        wave3Start = wave3.transform.position;
        wave4Start = wave4.transform.position;
        wave5Start = wave5.transform.position;
        wave6Start = wave6.transform.position;
        wave7Start = wave7.transform.position;
        wave8Start = wave8.transform.position;
        startWaveTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            StartWave();

        if (Time.time> startWaveTime+waveFreq && !isWaveStarted)
            StartWave();

        if (Time.time > startWaveTime + waveFreq + waveTime + Random.Range(0, 2.1f))
        {
            isWaveStarted = false;
            startWaveTime = Time.time;
        }

            if (isWaveStarted)
            MoveWaves();
    }

    void MoveWaves()
    {
        float t = Time.deltaTime;
        wave1.transform.position = new Vector3(wave1.transform.position.x - wave1Speed * waveSpeedMultiplier * t, wave1.transform.position.y, wave1.transform.position.z);
        wave2.transform.position = new Vector3(wave2.transform.position.x - wave2Speed * waveSpeedMultiplier * t, wave2.transform.position.y, wave2.transform.position.z);
        wave3.transform.position = new Vector3(wave3.transform.position.x - wave3Speed * waveSpeedMultiplier * t, wave3.transform.position.y, wave3.transform.position.z);
        wave4.transform.position = new Vector3(wave4.transform.position.x - wave4Speed * waveSpeedMultiplier * t, wave4.transform.position.y, wave4.transform.position.z);
        wave5.transform.position = new Vector3(wave5.transform.position.x - wave5Speed * waveSpeedMultiplier * t, wave5.transform.position.y, wave5.transform.position.z);
        wave6.transform.position = new Vector3(wave6.transform.position.x - wave6Speed * waveSpeedMultiplier * t, wave6.transform.position.y, wave6.transform.position.z);
        wave7.transform.position = new Vector3(wave7.transform.position.x - wave7Speed * waveSpeedMultiplier * t, wave7.transform.position.y, wave7.transform.position.z);
        wave8.transform.position = new Vector3(wave8.transform.position.x - wave8Speed * waveSpeedMultiplier * t, wave8.transform.position.y, wave8.transform.position.z);
    }

    private void StartWave()
    {
        isWaveStarted = true;
        wave1.transform.position = wave1Start;
        wave2.transform.position = wave2Start;
        wave3.transform.position = wave3Start;
        wave4.transform.position = wave4Start;
        wave5.transform.position = wave5Start;
        wave6.transform.position = wave6Start;
        wave7.transform.position = wave7Start;
        wave8.transform.position = wave8Start;

        float waveBGSpeed = mainWBS.waveSpeed;

        float scale = Random.Range(1.5f+waveBGSpeed, 1.5f + waveBGSpeed *4);
        wave1.transform.localScale = new Vector3(scale, scale, 1);
        wave2.transform.localScale = new Vector3(scale, scale, 1);
        wave3.transform.localScale = new Vector3(scale, scale, 1);
        wave4.transform.localScale = new Vector3(scale, scale, 1);
        wave5.transform.localScale = new Vector3(scale, scale, 1);
        wave6.transform.localScale = new Vector3(scale, scale, 1);
        wave7.transform.localScale = new Vector3(scale, scale, 1);
        wave8.transform.localScale = new Vector3(scale, scale, 1);
    }

}
