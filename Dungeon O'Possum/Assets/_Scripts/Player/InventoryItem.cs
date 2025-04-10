using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Tutorial: https://www.youtube.com/watch?v=geq7lQSBDAE
[Serializable]
public class InventoryItem {
    public ItemData itemData;
    public int stackSize; 

    //Constructor
    public InventoryItem(ItemData item) {
        itemData = item; 
        AddToStack();
    }

    //Increment/Decrement from stacks
    public void AddToStack() { stackSize++; }
    public void RemoveFromStack(){ stackSize--; }
}