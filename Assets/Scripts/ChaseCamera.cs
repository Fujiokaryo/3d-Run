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
        offset = transform.position - target.transform.position;
        offset.x = 0;
    }

    void Update()
    {
        if (target != null)
        {           
            transform.position = new Vector3(0,target.transform.position.y,target.transform. position.z) + offset;
        }
    }
}
