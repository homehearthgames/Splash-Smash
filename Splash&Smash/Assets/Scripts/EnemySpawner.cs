using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float enemyFreq;
    private float startEnemyTime;
    private float curTime;
    public GameObject enemyObj;
    public GameObject surfboardObj;
    private bool isMoving = false;
    public Sprite[] enemySpr;
    public Sprite[] surfboardSpr;
    public AudioClip[] enemySound;

    void Start()
    {
        startEnemyTime = Time.time + Random.Range(0, enemyFreq);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(Time.time);
        if (Time.time > startEnemyTime + enemyFreq && !isMoving)
        {
            // spawn obstacle

            GameObject newSurfboard = Instantiate(surfboardObj);
            newSurfboard.transform.SetParent(transform);
            GameObject newEnemy = Instantiate(enemyObj, newSurfboard.transform);
            newSurfboard.transform.position = surfboardObj.transform.position;

            transform.position = new Vector3(transform.position.x, -.5f, transform.position.y);


            int y = Random.Range(0, -5); // pick lane
            newSurfboard.transform.localPosition = new Vector3(0, y, newSurfboard.transform.localPosition.z);
            Debug.Log("Enemy y:" + y);

            // pick random surfboard sprite
            int sprNum = Random.Range(0, surfboardSpr.Length);
            newSurfboard.GetComponent<SpriteRenderer>().sprite = surfboardSpr[sprNum];

            // pick random enemy sprite
            sprNum = Random.Range(0, enemySpr.Length);
            newEnemy.GetComponent<SpriteRenderer>().sprite = enemySpr[sprNum];

            // enable enemy script
            newEnemy.GetComponent<EnemyScript>().enabled = true;

            // reset timer
            startEnemyTime = Time.time + Random.Range(0, enemyFreq);
        }


    }


}
