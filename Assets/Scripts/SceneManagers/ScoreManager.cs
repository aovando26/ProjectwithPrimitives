using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score = 0;

    void Start()
    {

    }

    void Update()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int value)
    {
        score = score + value;
        Debug.Log("Target has been hit " + score);
    }
}