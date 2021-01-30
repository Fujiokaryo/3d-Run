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
    private PlayerController playerController;
    private RightplayerCon rightplayerCon;
    
    void Start()
    {
        playerController = GameObject.Find("unitychan").GetComponent<PlayerController>();
        rightplayerCon = GameObject.Find("unitychan").GetComponent<RightplayerCon>();
    }

    // Update is called once per frame
    void Update()
    {
    
        keepPlayTime += Time.deltaTime;

        if(GameData.instance.currentPlayType == PlayType.SoloPlay && playerController.GameOver == true)
        {
            return;
        }
        else if(GameData.instance.currentPlayType == PlayType.DuoPlay && rightplayerCon.GameOver == true)
        {
            return;
        }

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

        if(GameData.instance.currentPlayType == PlayType.SoloPlay)
        {
            if (playerController.GameOver == false)
            {
                PlayTimeText.text = keepPlayTime.ToString("F2");
            }
        }
        else if(GameData.instance.currentPlayType == PlayType.DuoPlay)
        {
            if (rightplayerCon.GameOver == false)
            {
                PlayTimeText.text = keepPlayTime.ToString("F2");
            }
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

    public void ScoreCheck()
    {
        if(GameData.instance.currentPlayType == PlayType.SoloPlay)
        {
            GameData.instance.LoadHighScore();
            if(GameData.instance.soloHighScore < score)
            {
                GameData.instance.SaveHighScore(PlayType.SoloPlay, score);
            }
        }
        else if(GameData.instance.currentPlayType == PlayType.DuoPlay)
        {
            GameData.instance.LoadHighScore();
            if(GameData.instance.duoHighScore < score)
            {
                GameData.instance.SaveHighScore(PlayType.DuoPlay, score);
            }
        }
    }

}
