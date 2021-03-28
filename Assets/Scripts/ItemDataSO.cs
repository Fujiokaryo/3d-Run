using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Create ItemDataSO")]
public class ItemDataSO : ScriptableObject
{
    public List<ItemData> itemDataList = new List<ItemData>();

    [Serializable]
   public class ItemData
    {            
        public ItemType itemType;

        public float value;

    }

    public enum ItemType
    {
        HP,
        fullHP,
        Score,
        Jump,
        Wall,
        None
    }

    
}
