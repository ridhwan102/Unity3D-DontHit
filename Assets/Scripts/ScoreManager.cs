using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public float jedaScore;
    public float tambahanScore;

    [HideInInspector]
    public bool GameIsRun = true;
    private float score, timer;

    void Update()
    {
        if (GameIsRun)
        {
            timer += Time.deltaTime;
            if (timer > jedaScore && GameIsRun)
            {
                if (timer < jedaScore + 0.1)
                {
                    score += tambahanScore;
                }
                else timer = 0;
            }
        }
        scoreText.text = score.ToString();
    }
}
