using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroy : MonoBehaviour
{
    private GameObject gameMaster;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
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
        if(gameObject.tag == "ScoreItem" && other.gameObject.tag == "Player")
        {
            gameMaster.GetComponent<GameMaster>().AddPoint();
        }

        if (gameObject.tag != "Wall"  && other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
