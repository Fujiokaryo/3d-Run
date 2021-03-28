using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject healEffect;

    [SerializeField]
    private AudioClip objSe;

    [SerializeField]
    private SetUpItem setUp;

    private GameObject player;

    private GameMaster gameMaster;

    private PlayerController playerController;
    private RightplayerCon rightplayerCon;
    
    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        player = GameObject.Find("unitychan");
        playerController = player.GetComponent<PlayerController>();
        rightplayerCon = GameObject.Find("unitychan").GetComponent<RightplayerCon>();
    }
    void Update()
    {
        if(transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameData.instance.currentPlayType == PlayType.SoloPlay)
        {
            if (playerController.GameOver == true)
            {
                return;
            }
        }
        else if (GameData.instance.currentPlayType == PlayType.DuoPlay)
        {
            if (rightplayerCon.GameOver == true)
            {
                return;
            }
        }

        if(gameObject.tag == "ScoreItem")
        {
            gameMaster.GetComponent<GameMaster>().AddPoint(CheckItemPoint(gameMaster.gameLevel));
            AudioSource.PlayClipAtPoint(objSe, transform.position);
            Destroy(gameObject);
        }

        if(gameObject.tag == "HPItem")
        {
            GameObject heal = Instantiate(healEffect, transform.position, Quaternion.identity);
            heal.transform.position = new Vector3(heal.transform.position.x, heal.transform.position.y, heal.transform.position.z + 2f);
            Destroy(heal, 1.0f);
            AudioSource.PlayClipAtPoint(objSe, transform.position);
            Destroy(gameObject);
        }

        if (gameObject.tag == "fullHPItem")
        {
            GameObject heal = Instantiate(healEffect, transform.position, Quaternion.identity);
            heal.transform.position = new Vector3(heal.transform.position.x, heal.transform.position.y, heal.transform.position.z + 2f);
            Destroy(heal, 1.0f);
            AudioSource.PlayClipAtPoint(objSe, transform.position);
            Destroy(gameObject);
        }

        if (gameObject.tag == "JumpItem")
        {
            AudioSource.PlayClipAtPoint(objSe, transform.position);
            Destroy(gameObject);
        }

        if (gameObject.tag == "Wall")
        {
            AudioSource.PlayClipAtPoint(objSe, transform.position);
        }
    }

    private int CheckItemPoint(int gameLevel)
    {
        int itemPoint = (int)setUp.itemData.value;

        if (5 < gameLevel && gameLevel <= 10)
        {
            itemPoint = 500;
        }
        else if (10 < gameLevel)
        {
            itemPoint = 800;
        }

        return itemPoint;
    }
}
