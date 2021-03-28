using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpItem : MonoBehaviour
{
    [SerializeField]
    private int hpItemPer;

    [SerializeField]
    private int scoreItemPer;

    [SerializeField]
    private int jumpItemPer;

    public ItemDataSO.ItemType itemType;
    public void ItemSetUp(ItemDataSO.ItemType itemType)
    {
     

        if(itemType == ItemDataSO.ItemType.HP)
        {

            gameObject.tag = "HPItem";
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;

        }
        else if(itemType == ItemDataSO.ItemType.Score)
        {
            
            gameObject.tag = "ScoreItem";
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        }
        else if(itemType == ItemDataSO.ItemType.Jump)
        {
            
            gameObject.tag = "JumpItem";
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else if(itemType == ItemDataSO.ItemType.fullHP)
        {

            gameObject.tag = "fullHPItem";
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }



}
