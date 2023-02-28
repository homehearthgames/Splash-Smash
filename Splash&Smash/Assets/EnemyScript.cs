using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trickPointsObj;
    public GameObject scoreObj;
    public Canvas canvas;
    public WaveBGScript mainWBS; // used to get the player's aprox speed 0-.5
    public float speed;
    public GameObject enemySpawner;

    void Start()
    {
        SetClip();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogWarning("Col:"+collision.tag);
        if (collision.tag=="Weapon")
        {
            
            GameObject pObj = Instantiate(trickPointsObj, canvas.transform);
            pObj.GetComponent<TMP_Text>().text = "50";
            scoreObj.GetComponent<ScoreScript>().AddToScore(50);
            KillEnemy();
        }

    }

    void MoveEnemy()
    {
        float t = Time.deltaTime;
        float waveBGSpeed = mainWBS.waveSpeed;
        transform.parent.position = new Vector3(transform.parent.position.x - speed * t * waveBGSpeed, transform.parent.transform.parent.position.y, transform.parent.position.z);
        if (transform.parent.position.x < -20)
            Destroy(transform.parent.gameObject);

    }

    void KillEnemy()
    {
        //Debug.Log("kill enemy");
        GetComponent<Collider2D>().enabled = false;

        GetComponent<Rigidbody2D>().gravityScale = 1;

        GetComponent<AudioSource>().Play();


        //Debug.Log("spr:" + GetComponent<SpriteRenderer>().sprite);

        // disable surfboard collider
        transform.parent.GetComponent<BoxCollider2D>().enabled = false;

        //enemySpawner.PlaySound(GetComponent<SpriteRenderer>().sprite);

    }

    void PlayRandomSound(int startSound, int endSound, EnemySpawner es)
    {
        int s = Random.Range(startSound, endSound + 1);

        GetComponent<AudioSource>().clip = es.enemySound[s];
    }

    private void SetClip()
    {
        //Debug.Log("set clip");
        string spr = GetComponent<SpriteRenderer>().sprite.name;
        //Debug.Log("spr:" + spr);
        AudioClip clip;
        EnemySpawner es = enemySpawner.GetComponent<EnemySpawner>();

        if (spr == "Clown")
            GetComponent<AudioSource>().clip = es.enemySound[0];
        else
        if (spr == "Granny")
                    PlayRandomSound(12, 13, es);
                else
        if (spr == "Duck" || spr=="Duc" || spr=="Du")
                    PlayRandomSound(4, 11, es);
                else
                    PlayRandomSound(1, 3, es);
    }

}
