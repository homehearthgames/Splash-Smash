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
    public GameObject shadow;

    public GameObject player;
    public GameObject dude;
    private Animator dudeAnimator;

    public ParticleSystem ripple;

    public float movementSpeed;
    public float movementAccel;
    public float maxMovementSpeed;

    public int goodLandingRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dudeAnimator = dude.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.deltaTime;

        GetInput();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collide with wave
        if (collision.tag=="Wave" && !isJumping)
        {
            Debug.Log("Hit wave");
            ripple.gameObject.SetActive(false);
            isJumping = true;
            float waveHeight = collision.transform.localScale.x*.8f;
            var seq = LeanTween.sequence();

            seq.append(LeanTween.moveLocalY(gameObject, jumpHeight * waveHeight * (movementSpeed/2.7f+.9f), jumpTime).setEase(LeanTweenType.easeOutExpo)); // jump up

            // hang time for movement speed
            seq.append(movementSpeed*.7f);

            seq.append(LeanTween.moveLocalY(gameObject, 0, jumpTime).setEase(LeanTweenType.easeInExpo)); // jump down
            seq.append(() => { 
                Debug.Log("Landed");
                isJumping = false;

                // idle dude
                dudeAnimator.SetBool("Trick1", false);
                dude.GetComponent<Animator>().SetBool("Trick2", false);

                ResetSplash();
                float mult = 1.6f;
                splash1.startSpeed = waveHeight * 2 + 1.2f;
                splash2.startSpeed = waveHeight * 2 + 1.2f;
                splash3.startSpeed = waveHeight * 2 + 1.2f;

                splash1.maxParticles = (int)(waveHeight * 80);
                splash2.maxParticles = (int)(waveHeight * 80);
                splash3.maxParticles = (int)(waveHeight * 80);

                splash3.startSize = 1;

                //transform.localScale = new Vector3(waveHeight*mult, waveHeight * mult, 1);

                // hide shadow
                shadow.SetActive(false);
            }); ;

            seq.append(() => { //Reset player angle
                Debug.Log("Angle:" + transform.localEulerAngles.z+" dif:"+ Mathf.Clamp(MathF.Abs(0- transform.localEulerAngles.z), 0, 360));

                // slow down if you don't land within +- goodLandingRange degrees
                if (transform.localEulerAngles.z> goodLandingRange && transform.localEulerAngles.z<360- goodLandingRange)
                {
                    // ToDo: play splash / bad landing sound


                    // really bad landing
                    if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 360 - 90)
                    {
                        GameManager.gameManager.SetSpeed(0);
                        // big splash
                        splash1.startSpeed = waveHeight * 6 + 1.2f;
                        splash2.startSpeed = waveHeight * 6 + 1.2f;
                        splash3.startSpeed = waveHeight * 6 + 1.2f;

                        splash1.maxParticles = (int)(666);
                        splash2.maxParticles = (int)(666);
                        splash3.maxParticles = (int)(666);

                        splash3.startSize = 2.3f;

                    }
                    else // sorta bad landing
                        GameManager.gameManager.SetSpeed(.2f);

                }

                splash1.Play();
                splash2.Play();
                splash3.Play();
                splash4.Play();

                transform.localEulerAngles = new Vector3(0, 0, 0);
                isJumping = false;
                movementSpeed = 0;
                ripple.gameObject.SetActive(true);
            }); 

            seq.append(LeanTween.moveLocalY(gameObject, -.5f, .5f).setEase(LeanTweenType.easeOutExpo)); // dip down
            seq.append(() => { shadow.SetActive(true); }); //show shadow
            seq.append(LeanTween.moveLocalY(gameObject, 0, .5f).setEase(LeanTweenType.easeOutBounce)); // dip up
            Debug.Log("Wave size:" + waveHeight+" jump height: "+ (jumpHeight * waveHeight));
        }

        // Collide with Obstacle
        if (collision.tag == "Obstacle" && !isJumping)
        {
            movementSpeed = 0;
            GameManager.gameManager.SetSpeed(0);
            // set random sound pitch and volume
            collision.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1 - .2f, 1 + .2f);
            collision.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(1 - .4f, 1);
            collision.GetComponent<AudioSource>().Play();
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

    void GetInput()
    {
        if (Input.GetButton("Fire1") && !isJumping && dudeAnimator.GetBool("Trick1")==false && dudeAnimator.GetBool("Trick2") == false)
        {
            dudeAnimator.SetBool("Trick1", true);
        }

        if (Input.GetButton("Fire2") && !isJumping && dudeAnimator.GetBool("Trick1") == false && dudeAnimator.GetBool("Trick2") == false)
        {
            dudeAnimator.SetBool("Trick2", true);
        }

    }

}
