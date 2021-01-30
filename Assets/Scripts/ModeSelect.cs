using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    [SerializeField]
    private Text soloHighScoreText;

    [SerializeField]
    private Text duoHighScoreText;
    public void OnClick()
    {
        if(gameObject.tag == "solo")
        {
            SetPlayType(PlayType.SoloPlay);
            SceneManager.LoadScene("Solomode");
        }

        if (gameObject.tag == "duo")
        {
            SetPlayType(PlayType.DuoPlay);
            SceneManager.LoadScene("DuoMode");
        }
    }
    private void SetPlayType(PlayType selectPlayType)
    {
        GameData.instance.currentPlayType = selectPlayType;
    }

    private void Start()
    {
        GameData.instance.LoadHighScore();
        soloHighScoreText.text = GameData.instance.soloHighScore.ToString();
        duoHighScoreText.text = GameData.instance.duoHighScore.ToString(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameData.instance.SaveHighScore(GameData.instance.currentPlayType, GameData.instance.soloHighScore += 100);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            GameData.instance.SaveHighScore(PlayType.DuoPlay, GameData.instance.duoHighScore += 100);
        }
    }

}
