using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    Rigidbody2D rb;

    public bool isStopped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!isStopped)
        {
            MovePipes();
        }
        else
        {
            StopPipes();
        }
    }

    void StopPipes()
    {
        rb.velocity = Vector2.zero;
    }

    void MovePipes()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }
}
