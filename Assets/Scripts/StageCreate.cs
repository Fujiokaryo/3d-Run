﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
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

    [SerializeField]
    private List<GameObject> laneObjs =  new List<GameObject>();

    [SerializeField]
    private ItemDataSO itemDataSO;


    private int border = 1000;
    private int laneNum;
    private float playTime;
    private float objSpan;
    private PlayerController playerController;

    private const int maxLane = 4;
    private const int addBorder = 2000;
    private const float laneWidth = 1.6f;
    private const float initialWidth = -2.3f;


    void Start()
    {
        playerController = GameObject.Find("unitychan").GetComponent<PlayerController>();
        CheckGameLevel(gameMaster.gameLevel);
    }

    public void CheckGameLevel(int gameLevel)
    {
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

        if(gameLevel < 4)
        {
            wallPer = 50;
            itemPer = 30;
        }

        if (4 <= gameLevel && gameLevel <= 7)
        {
            wallPer = 60;
            itemPer = 15;
        }
        if (gameLevel > 7)
        {
            wallPer = 65;
            itemPer = 10;
        }


    }
    // Update is called once per frame
    void Update()
    {
       
        if (playerController.isStart == false)
        {
            return;
        }

        playTime += Time.deltaTime;
       

        if (transform.position.z > border)
        {
            CreateMap();
        }

        if (playTime > objSpan)
        {   
            
            laneObjs.Clear();

            PreparateCreateObjs();
            
            CheckWall();
            //Debug.Log(objSpan);
        }
    }

    /// <summary>
    /// 道の自動生成
    /// </summary>
    void CreateMap()
    {
        if(Stage1.transform.position.z < border)
        {
            border += addBorder;

            Vector3 temp = new Vector3(0, 0.05f, border);

            Stage1.transform.position = temp;
        }
        else if(Stage2.transform.position.z < border)
        {
            border += addBorder;

            Vector3 temp = new Vector3(0, 0.05f, border);

            Stage2.transform.position = temp;
        }
    }

    private void PreparateCreateObjs()
    {
        for (int i = 0; i < maxLane; i++)
        {
          CreateObj(i);
           
        }

        playTime = 0;
    }

    /// <summary>
    /// レーンのオブジェクト自動生成
    /// </summary>
    void CreateObj(int laneNum)
    {
        int randomValue = Random.Range(0, 100);
        int randomItemValue = Random.Range(0, 100);
        GameObject prefab = null;
        GameObject obj = null;


        if(randomValue < wallPer)
        {
            prefab = ObjPrefabs[0];
        }
        else if(wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            prefab = ObjPrefabs[1];
        }

        if(prefab != null)
        {
            obj = Instantiate(prefab, new Vector3(initialWidth + (laneNum * laneWidth), 0.6f, player.transform.position.z + 80f), Quaternion.identity);

            //Debug.Log("オブジェクト生成");

            if (wallPer <= randomValue && randomValue < wallPer + itemPer)
            {
                SetUpItem setUpItem = obj.GetComponent<SetUpItem>();
                //Debug.Log("コンポーネント取得");

                setUpItem.ItemSetUp(SelectItemType(randomItemValue));
            }

        }
       

        if(obj != null)
        {
            laneObjs.Add(obj);
        }
       
       
    }

   

    private void CheckWall()
    {
        //リストの中身が4個か確認 
        if (laneObjs.Count == 4)
        {
            //4個の場合にwallかどうかを1個ずつ確認＋全部wallの場合はランダムでどれかの壁をアイテムに変える
            for (int i = 0;i < laneObjs.Count; i++)
            {
                if(laneObjs[i].tag != "wall")
                {
                    break;
                }

            }
            
           //ランダムで壁を一つ選んで消す
           int value = Random.Range(0, laneObjs.Count);
            Destroy(laneObjs[value]);
            laneObjs.Remove(laneObjs[value]);

           int randomItemValue = Random.Range(0, 100);
           GameObject obj = null;

            obj = Instantiate(ObjPrefabs[1], new Vector3(-2.3f + laneWidth * value, 0.6f, player.transform.position.z + 80f), Quaternion.identity);

            SetUpItem setUpItem = obj.GetComponent<SetUpItem>();

            setUpItem.ItemSetUp(SelectItemType(randomItemValue));

            laneObjs.Insert(value, obj);
        }

        

    }

    ItemDataSO.ItemData SelectItemType(int randomItemValue)
    {

        if (randomItemValue < hpItemPer)
        {

            return itemDataSO.itemDataList[1];

        }
        else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
        {

            return itemDataSO.itemDataList[3];

        }
        else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
        {

            return itemDataSO.itemDataList[4];
        }

        return itemDataSO.itemDataList[0];
    }
}
