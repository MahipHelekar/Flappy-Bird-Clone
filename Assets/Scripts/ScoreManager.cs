using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;

    public void IncrementScore()
    {
        score++;
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
