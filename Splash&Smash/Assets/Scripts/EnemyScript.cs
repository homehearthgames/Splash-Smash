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
    private GameObject player;

    private float yMoveSpeed=.6f;
    int tweenID;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.LogWarning("Player:" + player.name);
        SetClip();


        // if Zombi sprite then hover
        if (GetComponent<SpriteRenderer>().sprite.name == "Zombi")
        {

            tweenID = LeanTween.moveLocalY(gameObject, .3f, 1).setEase(LeanTweenType.easeInOutBounce).setLoopPingPong(999).id;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.isFinished == false)
            MoveEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogWarning("Col:"+collision.tag);
        if (collision.tag=="Weapon")
        {
            player.GetComponent<PlayerMovement>().character.GetComponent<PlayerScript>().AddPoints(50);
            KillEnemy();
        }

    }

    void MoveEnemy()
    {
        float t = Time.deltaTime;
        float waveBGSpeed = mainWBS.waveSpeed;
        // move surfboard (parent)
        transform.parent.position = new Vector3(transform.parent.position.x - speed * t * waveBGSpeed, transform.parent.position.y, transform.parent.position.z);
        if (transform.parent.position.x < -20)
            Destroy(transform.parent.gameObject);

        // if sprite name is Clown, then follow player
        if (GetComponent<SpriteRenderer>().sprite.name=="Clown")
        {
            if (transform.parent.localPosition.x > -10 && transform.parent.GetComponent<BoxCollider2D>().enabled) // only follow player if x pos is not too close and has an enemy on it
            {
                if (transform.parent.transform.position.y < player.transform.position.y)
                    transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y + yMoveSpeed * t, transform.parent.position.z);


                if (transform.parent.transform.position.y > player.transform.position.y)
                    transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y - yMoveSpeed * t, transform.parent.position.z);
            }
        }
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

        // disable shadow
        transform.parent.Find("Shadow").GetComponent<SpriteRenderer>().enabled = false;

        // disable lween moving up and down
        LeanTween.cancel(tweenID);

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
