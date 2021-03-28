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
    private int fullHPItemPer;

    [SerializeField]
    private GameMaster gameMaster;

    [SerializeField]
    private RightplayerCon rightplayerCon;

    [SerializeField]
    private ItemDataSO itemDataSO;

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
        
        if (rightplayerCon.isStart == false)
        {
            return;
        }

        playTime += Time.deltaTime;

        if (transform.position.z > border)
        {
            CreateMap();
        }       


        if (playTime > CreateObjSpan(gameMaster.gameLevel))
        {
            CreateLeftObj();
            CreateRightObj();
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
    /// 左側レーンのオブジェクト自動生成
    /// </summary>
    void CreateLeftObj()
    {
        int randomValue = Random.Range(0, 100);
        int randomItemValue = Random.Range(0, 100);
        if (randomValue < 50)
        {
            Instantiate(ObjPrefabs[0], new Vector3(-2.5f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            if (randomValue < 20)
            {
                
              GameObject obj = Instantiate(ObjPrefabs[1], new Vector3(-0.9f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);

              SetUpItem setUpItem = obj.GetComponent<SetUpItem>();

              setUpItem.ItemSetUp(SelectItemType(randomItemValue));
               
            }

        }
        else if (50 <= randomValue)
        {
            Instantiate(ObjPrefabs[0], new Vector3(-0.9f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            if (80 <= randomValue)
            {
                GameObject obj = Instantiate(ObjPrefabs[1], new Vector3(-2.5f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);

                SetUpItem setUpItem = obj.GetComponent<SetUpItem>();

                setUpItem.ItemSetUp(SelectItemType(randomItemValue));
            }
        }
        playTime = 0;
    }

    /// <summary>
    /// 右側レーンのオブジェクト自動生成
    /// </summary>
    void CreateRightObj()
    {
        int randomValue = Random.Range(0, 100);
        int randomItemValue = Random.Range(0, 100);
        if (randomValue < 50)
        {
            Instantiate(ObjPrefabs[0], new Vector3(0.9f, 0.6f, player.transform.position.z + 80f), Quaternion.identity);
            if (randomValue < 20)
            {

                GameObject obj = Instantiate(ObjPrefabs[1], new Vector3(2.5f, 0.6f, player.transform.position.z + 80f), Quaternion.identity);

                SetUpItem setUpItem = obj.GetComponent<SetUpItem>();

                setUpItem.ItemSetUp(SelectItemType(randomItemValue));
            }
        }
        else if(50 <= randomValue)
        {
            Instantiate(ObjPrefabs[0], new Vector3(2.5f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);
            if (80 <= randomValue)
            {
                
                GameObject obj  = Instantiate(ObjPrefabs[1], new Vector3(0.9f, 0.5f, player.transform.position.z + 80f), Quaternion.identity);

                SetUpItem setUpItem = obj.GetComponent<SetUpItem>();

                setUpItem.ItemSetUp(SelectItemType(randomItemValue));
            }
        }
        playTime = 0;
    }

    private float CreateObjSpan(int gameLevel)
    {
        if (gameLevel <= 2)
        {
            objSpan = 0.8f;
        }
        else if (2 < gameLevel && gameLevel <= 4)
        {
            objSpan = 0.6f;
        }
        else if (4 < gameLevel && gameLevel <= 6)
        {
            objSpan = 0.5f;
        }
        else if (6 < gameLevel && gameLevel <= 8)
        {
            objSpan = 0.4f;
        }
        else if (gameLevel > 8)
        {
            objSpan = 0.3f;
        }

        return objSpan;
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
        else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + fullHPItemPer)
        {

            return itemDataSO.itemDataList[2];
        }

        return itemDataSO.itemDataList[0];
    }
}

   