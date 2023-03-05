using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float curTime;

    public float playerSpeedX;
    public float playerSpeedY;
    public float rotSpeed;
    public Transform xMin;
    public Transform xMax;
    public Transform yMin;
    public Transform yMax;

    public GameObject character;
    public Animator dudeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.isFinished == false)
        {
            curTime = Time.deltaTime;
            GetInput();
        }
    }


    void GetInput()
    {
        float speed;
        if (GetComponentInChildren<PlayerScript>().isJumping != true)
            speed = playerSpeedX;
        else
            speed = playerSpeedX / 2;

        if (Input.GetAxis("Horizontal") < 0 && transform.position.x - speed * curTime > xMin.position.x)
        {
            transform.position = new Vector3(transform.position.x - speed * curTime, transform.position.y, transform.position.z);
        }
        if (Input.GetAxis("Horizontal") > 0 && transform.position.x + speed * curTime < xMax.position.x)
        {
            transform.position = new Vector3(transform.position.x + speed * curTime, transform.position.y, transform.position.z);
            character.GetComponent<PlayerScript>().movementSpeed += character.GetComponent<PlayerScript>().movementAccel* curTime;
            if (character.GetComponent<PlayerScript>().movementSpeed > character.GetComponent<PlayerScript>().maxMovementSpeed)
                character.GetComponent<PlayerScript>().movementSpeed = character.GetComponent<PlayerScript>().maxMovementSpeed;
        }

        if (!(Input.GetAxis("Horizontal") > 0)) // if not pressing right then movement speed=0
            character.GetComponent<PlayerScript>().movementSpeed = 0;


        // only do vertical movement when not jumping
        if (GetComponentInChildren<PlayerScript>().isJumping!=true)
        {
            if (Input.GetAxis("Vertical") > 0 && transform.position.y + playerSpeedY * curTime < yMin.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + playerSpeedY * curTime, transform.position.z);
            }
            if (Input.GetAxis("Vertical") < 0 && transform.position.y - playerSpeedY * curTime > yMax.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeedY * curTime, transform.position.z);
            }
        }
        else // player jumping so you and rotate
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                character.transform.localEulerAngles = new Vector3(0,0, character.transform.localEulerAngles.z+(curTime * rotSpeed));
                // get points
                if (dudeAnimator.GetBool("Trick1") == true || dudeAnimator.GetBool("Trick2") == true)
                    GetComponentInChildren<PlayerScript>().curTrickPoints += 150f * curTime;
                else
                    GetComponentInChildren<PlayerScript>().curTrickPoints += 104f * curTime;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                character.transform.localEulerAngles = new Vector3(0, 0, character.transform.localEulerAngles.z-(curTime * rotSpeed));
                // get points
                if (dudeAnimator.GetBool("Trick1") == true || dudeAnimator.GetBool("Trick2") == true)
                    GetComponentInChildren<PlayerScript>().curTrickPoints += 150f * curTime;
                else
                    GetComponentInChildren<PlayerScript>().curTrickPoints += 104f * curTime;
            }
        }

    }

}
