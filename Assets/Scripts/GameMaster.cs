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

    [SerializeField]
    private Text PlayTimeText;

    [SerializeField]
    private GameObject HPGauge;

    [SerializeField]
    private GameObject jumpIcon;

    [SerializeField]
    private GameObject countDownCanvas;

    [SerializeField]
    private GameObject scoreCanvas;

    [SerializeField]
    private GameObject levelCanvas;

    [SerializeField]
    private GameObject playTimeCanvas;

    public int gameLevel = 1;

    private int levelUp = 30;
    private int score;
    private int timeScore;
    private int itemPoint; 
    private float keepPlayTime = -3;
    private float keepPlayTimeSep = 3;
    private bool gameOver;
    
    void Start()
    {
        gameOver = GameObject.Find("unitychan").GetComponent<PlayerController>().GameOver;
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
            levelText.text = gameLevel.ToString();
            levelUp += 20;
        }
        if (gameOver == false)
        {
            PlayTimeText.text = keepPlayTime.ToString("F2");
        }
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
        scoreText.text = score.ToString();
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
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        HPGauge.SetActive(true);
        jumpIcon.SetActive(true);
        countDownCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        levelCanvas.SetActive(true);
        playTimeCanvas.SetActive(true); 
    }

}
