 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DentedPixel;
using TMPro;

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

    public GameObject dude;
    private Animator dudeAnimator;
    public GameObject weapon;


    public ParticleSystem ripple;

    public float movementSpeed;
    public float movementAccel;
    public float maxMovementSpeed;

    public int goodLandingRange;

    private float startAngle;
    public int trickPoints;
    public float curTrickPoints;
    public GameObject trickPointsObj;
    public GameObject scoreObj;
    private float trickStartTime;
    private float trickEndTime;

    public Canvas canvas;

    public AudioClip[] ComboSound;

    // Start is called before the first frame update
    void Start()
    {
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

            startAngle = transform.localEulerAngles.z;

            curTrickPoints = 0;

            // if you are doing a trick when you hit the wave, you crash
            if (dudeAnimator.GetBool("Trick1") || dudeAnimator.GetBool("Trick2"))
            {
                WipeOut(collision);
                GetComponent<AudioSource>().clip = ComboSound[6]; // "Too bad"
                GetComponent<AudioSource>().Play();
            }


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
                if (transform.localEulerAngles.z > 45 && transform.localEulerAngles.z < 360 - 45)
                {
                    
                        Debug.Log("bad landing");
                        GameManager.gameManager.SetSpeed(0);
                    // big splash
                    splash1.startSpeed = waveHeight * 6 + 1.2f;
                    splash2.startSpeed = waveHeight * 6 + 1.2f;
                    splash3.startSpeed = waveHeight * 6 + 1.2f;

                    var main = splash1.main;
                    main.maxParticles = (int)(666);
                    main = splash2.main;
                    main.maxParticles = (int)(666);
                    main = splash3.main;
                    main.maxParticles = (int)(666);
                    splash3.startSize = 2.3f;
                    // play sound
                    GameObject wav = GameObject.FindGameObjectWithTag("Wave");

                    wav.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1 - .2f, 1 + .2f);
                    wav.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(1 - .4f, 1);
                    wav.GetComponent<AudioSource>().Play();

                    GetComponent<AudioSource>().clip = ComboSound[7]; // Aweful
                    GetComponent<AudioSource>().Play();

                }
                else // good landing
                {
                    Debug.Log("Good Landing");
                    AddPoints(curTrickPoints);

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
            WipeOut(collision);

        }

    public void AddPoints(float pts)
    {
        trickPoints = (int)(pts);
        trickPoints = trickPoints / 10;
        trickPoints = trickPoints * 10;

        // put point text at player pos
        //trickPointsObj.transform.position = new Vector3(Camera.main.WorldToScreenPoint(player.transform.position).x, Camera.main.WorldToScreenPoint(player.transform.position).y);
        if (trickPoints > 0)
        {
            GameObject pObj = Instantiate(trickPointsObj, canvas.transform);
            pObj.GetComponent<TMP_Text>().text = trickPoints.ToString();
            pObj.GetComponent<PointsScript>().trickPoints = trickPoints;

            // radical [0]  Extreme [1]   Sick[2]   Awesome[3]   Great[4]   Good[5]    Too Bad[6]   Awweful[7]
            int s = 0;
            if (trickPoints < 50)
                s = 5;
            else
                if (trickPoints < 150)
                s = 4;
            else
                if (trickPoints < 250)
                s = 3;
            else
                if (trickPoints < 350)
                s = 2;
            else
                if (trickPoints < 450)
                s = 1;
            else
                s = 0;


            GetComponent<AudioSource>().clip = ComboSound[s];
            GetComponent<AudioSource>().Play();

        }
    }

    private void WipeOut(Collider2D collision)
    {
        movementSpeed = 0;
        GameManager.gameManager.SetSpeed(0);
        // set random sound pitch and volume
        collision.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1 - .2f, 1 + .2f);
        collision.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(1 - .4f, 1);
        collision.GetComponent<AudioSource>().Play();

        // splash particles
        splash1.startSpeed = 2 * 6 + 1.2f;
        splash2.startSpeed = 2 * 6 + 1.2f;
        splash3.startSpeed = 2 * 6 + 1.2f;

        var main = splash1.main;
        main.maxParticles = (int)(666);
        main = splash2.main;
        main.maxParticles = (int)(666);
        main = splash3.main;
        main.maxParticles = (int)(666);

        splash3.startSize = 2.3f;
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
        // Tricks
        if (Input.GetButtonDown("Fire1"))
        {
            if (dudeAnimator.GetBool("Trick1") == false)
            {
                dudeAnimator.SetBool("Trick1", true);
                dudeAnimator.SetBool("Trick2", false);
                trickStartTime = Time.time;
            }
            else
            {
                dudeAnimator.SetBool("Trick1", false);
                trickEndTime = Time.time;
                AddPoints((trickEndTime- trickStartTime)*20.5f);
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (dudeAnimator.GetBool("Trick2") == false)
            {
                dudeAnimator.SetBool("Trick2", true);
                dudeAnimator.SetBool("Trick1", false);
                trickStartTime = Time.time;
            }
            else
            {
                dudeAnimator.SetBool("Trick2", false);
                trickEndTime = Time.time;
                AddPoints((trickEndTime - trickStartTime)*20.5f);
            }
        }

        // attack
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire3"))
        {
            // Call the PlayerAttack function

            weapon.GetComponent<WeaponScript>().PlayerAttack();

        }

    }



}
