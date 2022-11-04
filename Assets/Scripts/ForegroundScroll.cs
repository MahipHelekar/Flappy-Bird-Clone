using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundScroll : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;
    public bool stopScroll;

    void Start() 
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update() 
    {
        if(!stopScroll)
        {
            Scroll();
        }
    }

    void Scroll()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
