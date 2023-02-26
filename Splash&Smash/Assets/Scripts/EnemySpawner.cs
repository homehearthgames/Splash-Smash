using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveBGScript mainWBS; // used to get the player's aprox speed 0-.5

    public float enemyFreq;
    private float startEnemyTime;
    private float curTime;
    public GameObject enemyObj;
    public GameObject surfboardObj;
    private bool isMoving = false;
    public float speed;

    public Sprite[] enemySpr;
    public Sprite[] surfboardSpr;
    public AudioSource[] enemySound;

    void Start()
    {
        startEnemyTime = Time.time + Random.Range(0, 3.4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(Time.time);
        if (Time.time > startEnemyTime + enemyFreq && !isMoving)
        {
            // spawn obstacle
            int y = Random.Range(0, -4); // pick lane
            surfboardObj.transform.localPosition = new Vector3(0, y, surfboardObj.transform.localPosition.z);
            isMoving = true;
            // pick random surfboard sprite
            int sprNum = Random.Range(0, surfboardSpr.Length);
            surfboardObj.GetComponent<SpriteRenderer>().sprite = surfboardSpr[sprNum];

            // pick random enemy sprite
            sprNum = Random.Range(0, enemySpr.Length);
            enemyObj.GetComponent<SpriteRenderer>().sprite = enemySpr[sprNum];
        }

        if (isMoving)
            MoveEnemy();
    }

    void MoveEnemy()
    {
        float t = Time.deltaTime;
        float waveBGSpeed = mainWBS.waveSpeed;
        surfboardObj.transform.position = new Vector3(surfboardObj.transform.position.x - speed * t* waveBGSpeed, surfboardObj.transform.position.y, surfboardObj.transform.position.z);
        if (surfboardObj.transform.position.x < -20)
            isMoving = false;
        startEnemyTime = Time.time + Random.Range(0, 5.4f);
    }
}
