using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour  {

    [SerializeField] GameObject slotPrefab;
    [SerializeField] List<InventorySlot> slots = new List<InventorySlot>(12); //cap at 12



    private void OnEnable(){
        Inventory.OnInventoryChange += DrawInventory; 
    }
    private void OnDisable(){
        Inventory.OnInventoryChange -= DrawInventory; 
    }


    //Wipe Inventory / catch call
    void ResetInventory()   {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
            slots = new List<InventorySlot>(12); 
        }
    }

    // Update is called once per frame
    void DrawInventory(List<InventoryItem> items) {
        ResetInventory();

        for (int i = 0; i < slots.Capacity; i++) {  CreateInventorySlot();  }
        for (int i = 0; i < slots.Count; i++) { slots[i].DrawSlot(items[i]); }
    }

    void CreateInventorySlot(){
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();
        slots.Add(newSlotComponent);
    }
}
