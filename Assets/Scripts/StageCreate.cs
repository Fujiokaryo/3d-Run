using System.Collections;
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
    private float objSpan;

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

    private int border = 1000;
    private float playTime;
    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        
        if(transform.position.z > border)
        {
            CreateMap();
        }

        if(playTime > objSpan)
        {   
            CreateObj1();
            CreateObj2();
            CreateObj3();
            CreateObj4();
        }
    }

    /// <summary>
    /// 道の自動生成
    /// </summary>
    void CreateMap()
    {
        if(Stage1.transform.position.z < border)
        {
            border += 2000;

            Vector3 temp = new Vector3(0, 0.05f, border);

            Stage1.transform.position = temp;
        }
        else if(Stage2.transform.position.z < border)
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
        if(randomValue < wallPer)
        {
           Instantiate(ObjPrefabs[0], new Vector3(-5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if(wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if(randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(-5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if(hpItemPer <= randomItemValue && randomItemValue <hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(-5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if(hpItemPer + scoreItemPer <= randomItemValue &&  randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(-5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
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
            Instantiate(ObjPrefabs[0], new Vector3(-1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if (wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if (randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(-1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(-1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(-1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
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
            Instantiate(ObjPrefabs[0], new Vector3(1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if (wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if (randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(1.5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
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
            Instantiate(ObjPrefabs[0], new Vector3(5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
        }
        else if (wallPer <= randomValue && randomValue < wallPer + itemPer)
        {
            if (randomItemValue < hpItemPer)
            {
                Instantiate(ObjPrefabs[1], new Vector3(5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
            {
                Instantiate(ObjPrefabs[3], new Vector3(5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
            else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
            {
                Instantiate(ObjPrefabs[2], new Vector3(5f, 1f, player.transform.position.z + 80f), Quaternion.identity);
            }
        }

        playTime = 0;
    }
}
