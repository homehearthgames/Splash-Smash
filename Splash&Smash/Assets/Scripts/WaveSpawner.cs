using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject wave1;
    public GameObject wave2;
    public GameObject wave3;
    public GameObject wave4;

    private Vector3 wave1Start;
    private Vector3 wave2Start;
    private Vector3 wave3Start;
    private Vector3 wave4Start;

    public float wave1Speed;
    public float wave2Speed;
    public float wave3Speed;
    public float wave4Speed;

    public float waveSpeedMultiplier;

    private bool isWaveStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        wave1Start = wave1.transform.position;
        wave2Start = wave2.transform.position;
        wave3Start = wave3.transform.position;
        wave4Start = wave4.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            StartWave();

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
    }

    private void StartWave()
    {
        isWaveStarted = true;
        wave1.transform.position = wave1Start;
        wave2.transform.position = wave2Start;
        wave3.transform.position = wave3Start;
        wave4.transform.position = wave4Start;
    }

}
