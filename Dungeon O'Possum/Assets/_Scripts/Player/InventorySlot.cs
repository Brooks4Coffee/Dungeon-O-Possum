using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

//tutorial:  https://www.youtube.com/watch?v=4-d9Vu3O2jk&list=TLPQMDgxMjIwMjS2UQNv76Oq1A&index=3
public class InventorySlot : MonoBehaviour  {
    
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI stackCount;


    public void ClearSlot()   {
        icon.enabled = false; 
        stackCount.enabled = false; 
    }

    // set data
    public void DrawSlot(InventoryItem item)  {
        if (item == null) {
            ClearSlot();
            return; 
        }
        icon.enabled = false; 
        stackCount.enabled = false; 

        icon.sprite = item.itemData.icon;
        stackCount.text = item.stackSize.ToString();
    }
}
