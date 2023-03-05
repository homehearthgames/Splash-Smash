using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public WaveBGScript mainWBS; // used to get the player's aprox speed 0-.5
    public float obsFreq;
    private float startObsTime;
    private float curTime;
    public GameObject obs;
    private bool isMoving=false;
    public float speed;

    public Sprite[] obsSpr;

    public float finishLineFreq;
    public GameObject finishLineObj;

    void Start()
    {
        startObsTime = Time.time + Random.Range(0, 5.4f);
        curTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // finish line
        if (Time.time > curTime + finishLineFreq)
            finishLineObj.SetActive(true);


        if (GameManager.gameManager.isFinished == false)
        {
            //Debug.LogWarning(Time.time);
            if (Time.time > startObsTime + obsFreq && !isMoving)
            {
                // spawn obstacle
                int y = Random.Range(0, -4);
                obs.transform.localPosition = new Vector3(0, y, obs.transform.localPosition.z);
                isMoving = true;
                // pick random obstacle sprite
                int sprNum = Random.Range(0, obsSpr.Length);
                obs.GetComponent<SpriteRenderer>().sprite = obsSpr[sprNum];
            }

            if (isMoving)
                MoveObs();
        }
    }

    void MoveObs()
    {
        float t = Time.deltaTime;
        float waveBGSpeed = mainWBS.waveSpeed;
        obs.transform.position = new Vector3(obs.transform.position.x - speed * t* waveBGSpeed, obs.transform.position.y, obs.transform.position.z);
        if (obs.transform.position.x < -20)
            isMoving = false;
        startObsTime = Time.time + Random.Range(0, 5.4f);
    }
}
