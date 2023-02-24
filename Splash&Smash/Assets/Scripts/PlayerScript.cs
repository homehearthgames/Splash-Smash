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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        float t = Time.deltaTime;
        if (Input.GetAxis("Horizontal")<0 && transform.position.x - playerSpeedX*t>xMin.position.x)
        {
            transform.position = new Vector3(transform.position.x - playerSpeedX * t, transform.position.y, transform.position.z);
        }
        if (Input.GetAxis("Horizontal") > 0 && transform.position.x + playerSpeedX * t < xMax.position.x)
        {
            transform.position = new Vector3(transform.position.x + playerSpeedX * t, transform.position.y, transform.position.z);
        }
        if (Input.GetAxis("Vertical") > 0 && transform.position.y + playerSpeedY * t < yMin.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + playerSpeedY * t, transform.position.z);
        }
        if (Input.GetAxis("Vertical") < 0 && transform.position.y - playerSpeedY * t > yMax.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeedY * t, transform.position.z);
        }
        



    }

}
