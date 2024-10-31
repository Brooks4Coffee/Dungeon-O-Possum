using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour  {
    
    [Header("Inventory:")]
    [SerializeField] int CoinsTotal;  //Total coins collected, does not count coins collected during adventure
    [SerializeField] int CoinsNew;    //reset to zero every new level, at end of level, add all to CoinsTotal
    


    void Awake()  {
        CoinsTotal = 0;
        CoinsNew = 0;
    }


    void Update()  {
        
    }


    //***********************************COIN OPERATIONS***********************************
    //Getter for Total Coins
    public int GetTotalCoinCount() {
        return CoinsTotal; 
    }

    //Getter for New Coins
    public int GetNewCoinCount() {
        return CoinsNew; 
    }

    //Setter for when we pick up new coins
    public void AddToNewCoins(int Coins) {
        CoinsNew += Coins; 
    }

    //End Of Level Operation: add new coins to total and reset new coin count
    public void AddUpAllCoins() {
        CoinsTotal += CoinsNew;     //add coins we've collected during adventure to total coins
        CoinsNew = 0;               //reset CoinsNew after adding it
    }


    //if u die, you loose random amount between 20% - 60%
    //  expecting decimal 0.2 -> 0.6
    public void LostValue(float percentageValue) {
        float Coins = CoinsNew * percentageValue; 
        CoinsNew = Mathf.FloorToInt(Coins);         //rounds to floow value 
    }

    //***********************************xyz OPERATIONS***********************************

}
