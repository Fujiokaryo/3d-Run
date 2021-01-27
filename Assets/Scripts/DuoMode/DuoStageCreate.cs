using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoStageCreate : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    public GameObject Stage1;

    [SerializeField]
    public GameObject Stage2;

    [SerializeField]
    public GameObject[] ObjPrefabs;

    [SerializeField]
    private int wallPer;

    [SerializeField]
    private int itemPer;

    [SerializeField]
    private int hpItemPer;

    [SerializeField]
    private int scoreItemPer;

    [SerializeField]
    private int jumpItemPer;

    [SerializeField]
    private GameMaster gameMaster;

    private int gameLevel;
    private int border = 1000;
    private float playTime;
    private float objSpan;
    private bool isStart;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isStart = GameObject.Find("unitychan").GetComponent<RightplayerCon>().isStart;
        if (isStart == false)
        {
            return;
        }

        playTime += Time.deltaTime;
        gameLevel = gameMaster.gameLevel;

        if (transform.position.z > border)
        {
            CreateMap();
        }

        if (gameLevel <= 2)
        {
            objSpan = 1.2f;
        }
        else if (2 < gameLevel && gameLevel <= 4)
        {
            objSpan = 1f;
        }
        else if (4 < gameLevel && gameLevel <= 6)
        {
            objSpan = 0.8f;
        }
        else if (6 < gameLevel && gameLevel <= 8)
        {
            objSpan = 0.6f;
        }
        else if (gameLevel > 8)
        {
            objSpan = 0.4f;
        }


        if (playTime > objSpan)
        {
            CreateObj1();
            CreateObj2();
            CreateObj3();
            CreateObj4();
            //Debug.Log(objSpan);
        }
    }

    /// <summary>
    /// 道の自動生成
    /// </summary>
    void CreateMap()
    {
        if (Stage1.transform.position.z < border)
        {
            border += 2000;

            Vector3 temp = new Vector3(0, 0.05f, border);

            Stage1.transform.position = temp;
        }
        else if (Stage2.transform.position.z < border)
        {
            border += 2000;

            Vector3 temp = new Vector3(0, 0.05f, border);

            Stage2.transform.position = temp;
        }
    }

    /// <summary>
    /// 1レーン目のオブジェクト自動生成
    /// </summary>
    void CreateObj1()
    {
        int randomValue = Random.Range(0, 100);
        int randomItemValue = Random.Range(0, 100);
        if (randomValue < wallPer)
        {
            Instantiate(ObjPrefabs[0], new Vector3(-2.2f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if (wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if (randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(-2.2f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(-2.2f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(-2.2f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
        }

        playTime = 0;
    }

    /// <summary>
    /// 2レーン目のオブジェクト自動生成
    /// </summary>
    void CreateObj2()
    {
        int randomValue = Random.Range(0, 100);
        int randomItemValue = Random.Range(0, 100);
        if (randomValue < wallPer)
        {
            Instantiate(ObjPrefabs[0], new Vector3(-0.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if (wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if (randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(-0.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(-0.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(-0.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
        }

        playTime = 0;
    }

    /// <summary>
    /// 3レーン目のオブジェクト自動生成
    /// </summary>
    void CreateObj3()
    {
        int randomValue = Random.Range(0, 100);
        int randomItemValue = Random.Range(0, 100);
        if (randomValue < wallPer)
        {
            Instantiate(ObjPrefabs[0], new Vector3(1f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if (wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if (randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(1f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(1f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(1f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
        }

        playTime = 0;
    }

    /// <summary>
    /// 4レーン目のオブジェクト自動生成
    /// </summary>
    void CreateObj4()
    {
        int randomValue = Random.Range(0, 100);
        int randomItemValue = Random.Range(0, 100);
        if (randomValue < wallPer)
        {
            Instantiate(ObjPrefabs[0], new Vector3(2.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if (wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if (randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(2.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(2.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(2.6f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            }
        }

        playTime = 0;
    }
}
