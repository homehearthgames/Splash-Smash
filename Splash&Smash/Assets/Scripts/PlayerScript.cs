using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeedX;
    public float playerSpeedY;
    public Transform xMin;
    public Transform xMax;
    public Transform yMin;
    public Transform yMax;
    private bool isJumping=false;
    public float jumpSpeed;
    private float curTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.deltaTime;
        GetInput();
        if (isJumping)
            Jumping();
    }

    void GetInput()
    {
        
        if (Input.GetAxis("Horizontal")<0 && transform.position.x - playerSpeedX* curTime > xMin.position.x)
        {
            transform.position = new Vector3(transform.position.x - playerSpeedX * curTime, transform.position.y, transform.position.z);
        }
        if (Input.GetAxis("Horizontal") > 0 && transform.position.x + playerSpeedX * curTime < xMax.position.x)
        {
            transform.position = new Vector3(transform.position.x + playerSpeedX * curTime, transform.position.y, transform.position.z);
        }
        if (Input.GetAxis("Vertical") > 0 && transform.position.y + playerSpeedY * curTime < yMin.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + playerSpeedY * curTime, transform.position.z);
        }
        if (Input.GetAxis("Vertical") < 0 && transform.position.y - playerSpeedY * curTime > yMax.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeedY * curTime, transform.position.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asdfsfd");
        if (collision.tag=="Wave")
        {
            isJumping = true;
        }
    }

    void Jumping()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + jumpSpeed* curTime, transform.position.z);
    }

}
