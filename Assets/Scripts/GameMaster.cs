using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    public Text scoreText;

    [SerializeField]
    public Text levelText;

    public int gameLevel = 1;

    private int levelUp = 30;
    private int score;
    private int timeScore;
    private int itemPoint; 
    private float keepPlayTime;
    private float keepPlayTimeSep = 3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keepPlayTime += Time.deltaTime;


        if (keepPlayTime > keepPlayTimeSep)
        {
            AddTimePoint();
        }

        if (keepPlayTime > levelUp)
        {
            gameLevel++;
            levelUp += 30;
        }

        levelText.text = gameLevel.ToString();
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// 時間経過でポイント加算
    /// </summary>
    void AddTimePoint()
    {
        if (gameLevel <= 5)
        {
            timeScore = 300;
        }
        else if (5 < gameLevel && gameLevel <= 10)
        {
            timeScore = 500;
        }
        else if (10 < gameLevel)
        {
            timeScore = 800;
        }

        score += timeScore;
        keepPlayTimeSep += 3;
    }

    /// <summary>
    /// アイテムによるポイント加算
    /// </summary>
    public void AddPoint()
    {
        if (gameLevel <= 5)
        {
            itemPoint = 500;
        }
        else if (5 < gameLevel && gameLevel <= 10)
        {
            itemPoint = 700;
        }
        else if (10 < gameLevel)
        {
            itemPoint = 1000;
        }

        score += itemPoint;
    }

}
