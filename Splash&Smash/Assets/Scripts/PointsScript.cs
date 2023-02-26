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
    private float alpha = 255;


    void Start()
    {
        rect = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<TMP_Text>().text!="" ) // is text has text
        {
            pointsMoving = true;
            rect.position = new Vector2(rect.position.x, rect.position.y + textSpeed*6);
            if (rect.localScale.x>.1f)
                rect.localScale = new Vector3(rect.localScale.x - textSpeed/4, rect.localScale.x - textSpeed/4, rect.localScale.x - textSpeed/4);

            //GetComponent<TMP_Text>().color = new Color(255, 255, 255, GetComponent<TMP_Text>().color.a-1);
        }
    }




}
