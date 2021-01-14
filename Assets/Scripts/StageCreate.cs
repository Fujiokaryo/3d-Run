using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    [SerializeField]
    public GameObject Stage1;

    [SerializeField]
    public GameObject Stage2;

    int border = 1000;

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
}
