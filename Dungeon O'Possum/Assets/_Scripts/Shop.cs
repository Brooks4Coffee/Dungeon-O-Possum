using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour  {

    [Header("Player's Inventory")]
    [SerializeField] Inventory inventory;

    [Header("Shop ShopItem List")]
    [SerializeField] List<ShopItem> ForSale; //List of ShopItems this shop sells 

    [Header("Shop UI: Panel")]
    [SerializeField] GameObject panel_Shopping; //Shop Panel 

    [Header("Shop UI: Text ")]
    [SerializeField] Text  ShopItemListText;    //Text for ShopItems


    void Start()  {
        DisplayShop(); 
    }


    void Update()  {
        //check for purchases
    }


    //Display Shop Items To Player
    void DisplayShop() {
        ShopItemListText.text = "";
        foreach (ShopItem ShopItem in ForSale) {
            ShopItemListText.text += ShopItem.ItemName + " - $" + ShopItem.price + "\n";
        }
        //TODO: Make interactable UI for buying things
    }

    //Buy Item From Shop (if you have enough money)
    void BuyShopItem(ShopItem ShopItem) {
        if (inventory.GetTotalCoinCount() < ShopItem.price) {
            Debug.Log("Not Enough Money To Buy " + ShopItem.ItemName + ". Need " + (ShopItem.price - inventory.GetTotalCoinCount()) + " more coins");
            //TODO: make notice text that says the above debug log
            return;
        } 
        Debug.Log("Bought " + ShopItem.ItemName);
        //TODO: add to inventory, minus price from totalCoins
        //TODO: take # of bought items out of shop
        //TODO: create regeneration function for shop items
    }
}



[System.Serializable]
public class ShopItem  {
    [SerializeField] public string ItemName;
    [SerializeField] public int price;
}