using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will allow us to make ItemData like as a gameobject
//Tutorial: https://www.youtube.com/watch?v=geq7lQSBDAE
[CreateAssetMenu(fileName = "NewItemData", menuName = "Item Data")]
public class ItemData : ScriptableObject  {
    public string displayName;
    public Sprite icon;         
}
/*
FUTURE USE: got from comment on video

    In ITEMDATA add the following bool after your other variable :
    public bool isStackable;

    in INVENTORY above everything in using add :
    using System.Linq;

    in INVENTORY still change the method Add(ItemData itemData) to :
        public void Add(ItemSO itemData)  {
            var thisItem = inventory.FirstOrDefault(x => x.itemData == itemData);
            if (thisItem != null && thisItem.itemData == itemData && thisItem.itemData.stackable)  {
                thisItem.AddToStack();
                OnInventoryChange?.Invoke(inventory);
            }
            else   {
                InventoryItem newItem = new(itemData);
                inventory.Add(newItem);
                OnInventoryChange?.Invoke(inventory);
            }
        }

    and for Remove method :
        public void Remove(ItemSO itemData) {
            var thisItem = inventory.FirstOrDefault(x => x.itemData == itemData);

            if (thisItem != null && thisItem.itemData == itemData) {
                thisItem.RemoveFromStack();
                if(thisItem.stackSize == 0) {
                    inventory.Remove(thisItem);
                }
                OnInventoryChange?.Invoke(inventory);
            }
        }
*/