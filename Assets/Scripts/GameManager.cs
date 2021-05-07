using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject ball;
    readonly Vector2 initialSpeed = new Vector2(2,2);
    void Start()
    {

    }


    void Update()
    {
        ListenForBallLaunch();
    }

    private void ListenForBallLaunch()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            ApplyInitialSpeedToBall();
        }
    }

    private void ApplyInitialSpeedToBall()
    {
        if (!ball)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
        }
        ball.GetComponent<Rigidbody2D>().velocity = initialSpeed;
    }
}
