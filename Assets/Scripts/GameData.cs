using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // ここに必要になる情報を public 修飾子で足していく
    public static GameData instance;

    public int soloHighScore;
    public int duoHighScore;
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
        PlayerPrefs.SetInt(savePlayType.ToString(), highscore);
        PlayerPrefs.Save();
        //Debug.Log(highscore);
    }

    public void LoadHighScore()
    {
       soloHighScore = PlayerPrefs.GetInt(PlayType.SoloPlay.ToString(), 0);
       duoHighScore = PlayerPrefs.GetInt(PlayType.DuoPlay.ToString(), 0);
    }


}
