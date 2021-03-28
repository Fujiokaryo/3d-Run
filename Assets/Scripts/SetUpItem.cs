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
    public void ItemTypeSetUp(int randomItemValue)
    {
        if(gameObject.tag == "Wall")
        {
            return;
        }

        if (randomItemValue < hpItemPer)
        {
            
            itemType = ItemDataSO.ItemType.HP;
            gameObject.tag = "HPItem";
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;

        }
        else if (hpItemPer <= randomItemValue && randomItemValue < hpItemPer + scoreItemPer)
        {
            
            itemType = ItemDataSO.ItemType.Score;
            gameObject.tag = "ScoreItem";
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        }
        else if (hpItemPer + scoreItemPer <= randomItemValue && randomItemValue <= hpItemPer + scoreItemPer + jumpItemPer)
        {
            
            itemType = ItemDataSO.ItemType.Jump;
            gameObject.tag = "JumpItem";
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }



}
