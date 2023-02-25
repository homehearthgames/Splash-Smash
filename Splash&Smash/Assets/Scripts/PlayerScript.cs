using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DentedPixel;

public class PlayerScript : MonoBehaviour
{
    
    public bool isJumping=false;
    public float jumpHeight;
    public float jumpTime;
    private float curTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.deltaTime;

        if (isJumping)
            Jumping();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Wave" && !isJumping)
        {
            Debug.Log("Hit wave");
            isJumping = true;
            float waveHeight = collision.transform.localScale.x;
            var seq = LeanTween.sequence(); 
            seq.append(LeanTween.moveLocalY(gameObject, jumpHeight * waveHeight, jumpTime).setEase(LeanTweenType.easeOutExpo)); // jump up

            seq.append(LeanTween.moveLocalY(gameObject, 0, jumpTime).setEase(LeanTweenType.easeInExpo)); // jump down
            seq.append(() => { // fire event after tween
                Debug.Log("Landed");
                isJumping = false;
            }); ;

            Debug.Log("Wave size:" + waveHeight+" jump height: "+ (jumpHeight * waveHeight));
        }
    }

    void Jumping()
    {
        
    }

}
