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

    [SerializeField]
    private Text soloBestPlayTimeText;

    [SerializeField]
    private Text DuoBestPlayTimeText;


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


    private void Start()
    {
        GameData.instance.LoadHighScore();
        soloHighScoreText.text = GameData.instance.soloHighScore.ToString();
        soloBestPlayTimeText.text = GameData.instance.soloBestPlay.ToString("F2") + "s";
        duoHighScoreText.text = GameData.instance.duoHighScore.ToString();
        DuoBestPlayTimeText.text = GameData.instance.duoBestPlay.ToString("F2") +  "s";


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

    private void SetPlayType(PlayType selectPlayType)
    {
        GameData.instance.currentPlayType = selectPlayType;
    }

}
