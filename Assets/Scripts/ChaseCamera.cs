using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 offset;
    void Start()
    {
        //カメラとプレイヤーの位置関係の取得
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = target.transform.position + offset;
        }
    }
}
