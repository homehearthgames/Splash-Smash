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

    public ParticleSystem splash1;
    public ParticleSystem splash2;
    public ParticleSystem splash3;
    public ParticleSystem splash4;

    public GameObject splash;

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
                ResetSplash();
                float mult = 1.6f;
                splash1.startSpeed = waveHeight * 3 + 2;
                splash2.startSpeed = waveHeight * 3 + 2;
                splash3.startSpeed = waveHeight * 3 + 2;

                splash1.maxParticles = (int)(waveHeight * 150);
                splash2.maxParticles = (int)(waveHeight * 150);
                splash3.maxParticles = (int)(waveHeight * 150);
                //transform.localScale = new Vector3(waveHeight*mult, waveHeight * mult, 1);
                splash1.Play();
                splash2.Play();
                splash3.Play();
                splash4.Play();
            }); ;
            seq.append(LeanTween.moveLocalY(gameObject, -1, 1).setEase(LeanTweenType.easeOutExpo)); // dip down
            seq.append(LeanTween.moveLocalY(gameObject, 0, 1).setEase(LeanTweenType.easeOutBounce)); // dip up


            Debug.Log("Wave size:" + waveHeight+" jump height: "+ (jumpHeight * waveHeight));
        }
    }

    void ResetSplash()
    {
        StartCoroutine(RSplash());
    }

    IEnumerator RSplash()
    {
        while(!splash1.isEmitting)
        {
            yield return null;
        }
        splash.transform.position = transform.position;
    }
    void Jumping()
    {
        
    }

}
