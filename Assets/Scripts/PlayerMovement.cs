using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;

    Rigidbody2D playerRb;
    public bool isPlayerDead;

    void Start() 
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if(!isPlayerDead)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Handle player movement
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }
}
