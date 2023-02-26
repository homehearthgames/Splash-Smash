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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning(collision.tag);
        if (collision.tag=="Weapon")
        {
            
            //GameObject pObj = Instantiate(trickPointsObj, canvas.transform);
            //pObj.GetComponent<TMP_Text>().text = "50";
            //scoreObj.GetComponent<ScoreScript>().AddToScore(50);
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;
        }

    }
}
