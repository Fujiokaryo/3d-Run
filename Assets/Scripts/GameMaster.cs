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

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject resultCanvas;

    [SerializeField]
    private Text highScoretext;

    [SerializeField]
    private Text resultScoreText;

    [SerializeField]
    private Text bestPlayTimeText;

    [SerializeField]
    private Text resultPlayTimeText;

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
        if(GameData.instance.currentPlayType == PlayType.SoloPlay && playerController.GameOver == true)
        {
            return;
        }
        else if(GameData.instance.currentPlayType == PlayType.DuoPlay && rightplayerCon.GameOver == true)
        {
            return;
        }

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

         PlayTimeText.text = keepPlayTime.ToString("F2");                  
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
            if(GameData.instance.soloHighScore < score)
            {
                GameData.instance.SaveHighScore(PlayType.SoloPlay, score);
            }

            if(GameData.instance.soloBestPlay < keepPlayTime)
            {
                GameData.instance.SaveBestplayTime(PlayType.SoloPlay, keepPlayTime);
            }
        }
        else if(GameData.instance.currentPlayType == PlayType.DuoPlay)
        {         
            if(GameData.instance.duoHighScore < score)
            {
                GameData.instance.SaveHighScore(PlayType.DuoPlay, score);
            }

            if(GameData.instance.duoBestPlay < keepPlayTime)
            {
                GameData.instance.SaveBestplayTime(PlayType.DuoPlay, keepPlayTime);
            }
        }
    }

    public void DisplayScore()
    {
        canvas.SetActive(false);
        resultCanvas.SetActive(true);
        if(GameData.instance.currentPlayType == PlayType.SoloPlay)
        {
            highScoretext.text = GameData.instance.soloHighScore.ToString();
            bestPlayTimeText.text = GameData.instance.soloBestPlay.ToString("F2") + "s";
            resultScoreText.text = score.ToString();
            resultPlayTimeText.text = keepPlayTime.ToString("F2") + "s";
        }
        else if(GameData.instance.currentPlayType == PlayType.DuoPlay)
        {
            highScoretext.text = GameData.instance.duoHighScore.ToString();
            bestPlayTimeText.text = GameData.instance.duoBestPlay.ToString("F2") + "s";
            resultScoreText.text = score.ToString();
            resultPlayTimeText.text = keepPlayTime.ToString("F2") + "s";
        }
    }

}
