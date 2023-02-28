using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DentedPixel;

public class PointsScript : MonoBehaviour
{
    bool pointsMoving = false;
    // Start is called before the first frame update
    private RectTransform rect;
    public float textSpeed;
    private GameObject player;

    private RectTransform canvasRT;
    private Vector3 roboScreenPos;

    private Transform score;
    public int trickPoints = 0;

    void Start()
    {
        score = GameObject.Find("Score").transform;
        rect = GetComponent<RectTransform>();

        player = GameObject.FindGameObjectWithTag("Player");

        canvasRT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        roboScreenPos = Camera.main.WorldToViewportPoint(player.transform.TransformPoint(new Vector3(0,-.7f,0)));
        rect.anchorMax = roboScreenPos;
        rect.anchorMin = roboScreenPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<TMP_Text>().text!="" && !pointsMoving) // is text has text
        {
            pointsMoving = true;
            rect.position = new Vector2(rect.position.x, rect.position.y + textSpeed*6);

            LeanTween.move(gameObject, score.position + new Vector3(-50, 0, 0), 2.2f).setOnComplete(AddToScore);
        }
    }

    void AddToScore()
    {
        Debug.Log("add");
        score.GetComponent<ScoreScript>().AddToScore(trickPoints);
        Destroy(gameObject);
    }


}
