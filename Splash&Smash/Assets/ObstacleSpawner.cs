using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public float obsFreq;
    private float startObsTime;
    private float curTime;
    public GameObject obs;
    private bool isMoving=false;
    public float speed;
    void Start()
    {
        startObsTime = Time.time + Random.Range(0, 5.4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(Time.time);
        if (Time.time>startObsTime+obsFreq && !isMoving)
        {
            // spawn obstacle
            int y = Random.Range(0, -4);
            obs.transform.localPosition = new Vector3(0,y,obs.transform.localPosition.z);
            isMoving = true;
            //Debug.LogError("Move Obs");
        }

        if (isMoving)
            MoveObs();
    }

    void MoveObs()
    {
        float t = Time.deltaTime;
        obs.transform.position = new Vector3(obs.transform.position.x - speed * t, obs.transform.position.y, obs.transform.position.z);
        if (obs.transform.position.x < -20)
            isMoving = false;
        startObsTime = Time.time + Random.Range(0, 5.4f);
    }
}
