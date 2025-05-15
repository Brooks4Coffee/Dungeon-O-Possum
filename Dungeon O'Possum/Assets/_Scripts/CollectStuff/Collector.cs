using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial Used: https://www.youtube.com/watch?v=f75Wcwu33OY
public class Collector : MonoBehaviour  {

    [Header("Game Manager:")]
    [SerializeField] GameManager gm; //send coin count and fish count


    [Header("Player's Inventory:")]  
    [SerializeField] Inventory inventory;
    // [SerializeField] public int XP;


    private void OnTriggerEnter2D(Collider2D other)  {
        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable != null) {
            collectable.Collect(); 
            inventory.AddToNewCoins(1);
            gm.addGold(1);
        }
    }
}
