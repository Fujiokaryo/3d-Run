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
    }

    void Update()
    {
        if (target != null)
        {           
            transform.position = target.transform.position + offset;
        }
    }
}
