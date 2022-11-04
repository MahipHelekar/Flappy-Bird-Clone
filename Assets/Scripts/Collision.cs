using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
    [SerializeField] AudioClip pointClip;
    
    TextMeshProUGUI scoreText;
    ScoreManager scoreManager;
    GameManager gameManager;

    void Start() 
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Pipes" || other.gameObject.tag == "Foreground")
        {
            gameManager.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Trigger")
        {
            scoreManager.IncrementScore();
            scoreText.text = scoreManager.GetCurrentScore().ToString();

            // Play the clip on the camera to hear it clearly
            AudioSource.PlayClipAtPoint(pointClip, Camera.main.transform.position);
        }
    }
}
