using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // ここに必要になる情報を public 修飾子で足していく
    public static GameData instance;

    public int soloHighScore;
    public int duoHighScore;
    public float soloBestPlay;
    public float duoBestPlay;
    public PlayType currentPlayType;
    
    private void Awake()
    {

        // シングルトンの確認と作成
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveHighScore(PlayType savePlayType, int highscore)
    {
        PlayerPrefs.SetInt(savePlayType.ToString() +"score", highscore);
        PlayerPrefs.Save();
        Debug.Log("checkscore");
    }

    public void SaveBestplayTime(PlayType savePlayType, float bestplaytime)
    {
        PlayerPrefs.SetFloat(savePlayType.ToString() + "time", bestplaytime);
        PlayerPrefs.Save();
        Debug.Log("checktime");
    }

    public void LoadHighScore()
    {
       soloHighScore = PlayerPrefs.GetInt(PlayType.SoloPlay.ToString() + "score", 0);
       duoHighScore = PlayerPrefs.GetInt(PlayType.DuoPlay.ToString() + "score", 0);
       soloBestPlay = PlayerPrefs.GetFloat(PlayType.SoloPlay.ToString() + "time", 0);
       duoBestPlay = PlayerPrefs.GetFloat(PlayType.DuoPlay.ToString() + "time", 0);
    }


}
