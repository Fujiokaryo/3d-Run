using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    [SerializeField]
    public GameObject Stage1;

    [SerializeField]
    public GameObject Stage2;

    [SerializeField]
    public GameObject[] randomObjPrefabs1;

    [SerializeField]
    public GameObject[] randomObjPrefabs2;

    [SerializeField]
    public GameObject[] randomObjPrefabs3;

    [SerializeField]
    public GameObject[] randomObjPrefabs4;


    [SerializeField]
    int wallgenSpan;

    int border = 1000;
    int wallBorder = 10;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > border)
        {
            CreateMap();
        }

        if(transform.position.z > wallBorder)
        {   
            CreateObj();           
        }
    }

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

    void CreateObj()
    {
        Instantiate(randomObjPrefabs1[Random.Range(0, randomObjPrefabs1.Length)], new Vector3(-5f, 1f, wallBorder + 80f), Quaternion.identity);

        Instantiate(randomObjPrefabs2[Random.Range(0, randomObjPrefabs2.Length)], new Vector3(-1.5f, 1f, wallBorder + 80f), Quaternion.identity);

        Instantiate(randomObjPrefabs3[Random.Range(0, randomObjPrefabs3.Length)], new Vector3(1.5f, 1f, wallBorder + 80f), Quaternion.identity);

        Instantiate(randomObjPrefabs4[Random.Range(0, randomObjPrefabs4.Length)], new Vector3(5f, 1f, wallBorder + 80f), Quaternion.identity);

        wallBorder += wallgenSpan;
    }
}
