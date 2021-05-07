using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInput : NetworkBehaviour
{
    float moveSpeed = 3;
    float vertical;
    Rigidbody2D paddleRB;
    Rigidbody2D rb;
    public GameObject playerPaddle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //[ServerCallback]
    public void SetPlayerPaddle(GameObject paddle)
    {
        playerPaddle = paddle;
        paddleRB = playerPaddle.GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        HandleKeyPress();
    }

    //[ServerCallback]
    private void FixedUpdate()
    {
       float v = vertical * moveSpeed;
        //paddleRB.velocity = new Vector2(0, v);
        rb.velocity = new Vector2(0, v);
    }

    //[ClientCallback]
    private void HandleKeyPress()
    { 
        if (!hasAuthority) { return; }
        vertical = Input.GetAxis("Vertical");
    }
}
