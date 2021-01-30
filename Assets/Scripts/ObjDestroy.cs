﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject healEffect;

    [SerializeField]
    private AudioClip objSe;

    private GameObject player;

    private GameObject gameMaster;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
        player = GameObject.Find("unitychan");
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

        if(gameObject.tag == "ScoreItem")
        {
            gameMaster.GetComponent<GameMaster>().AddPoint();
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

        if(gameObject.tag == "JumpItem")
        {
            AudioSource.PlayClipAtPoint(objSe, transform.position);
            Destroy(gameObject);
        }

        if (gameObject.tag == "Wall")
        {
            AudioSource.PlayClipAtPoint(objSe, transform.position);
        }
    }
}
