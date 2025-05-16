using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorials: https://www.youtube.com/watch?v=geq7lQSBDAE
public class Inventory : MonoBehaviour
{

	public static Inventory instance;
	public static event Action<List<InventoryItem>> OnInventoryChange;


	[Header("Game Manager:")]
	[SerializeField] GameManager gm; //send coin count and fish count

	[Header("Coins:")]
	[SerializeField] int CoinsTotal;  //Total coins collected, does not count coins collected during adventure
	[SerializeField] int CoinsNew;    //reset to zero every new level, at end of level, add all to CoinsTotal

	[Header("Fish Caught:")]
	[SerializeField] int fishCount = 0;


	[Header("Inventory:")]
	public List<InventoryItem> inventory = new List<InventoryItem>();
	private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();


	void Awake()
	{
		if (instance == null) { instance = this; }
		else { Destroy(this.gameObject); }
		DontDestroyOnLoad(gameObject);
	}


	//**************************        GM OPERATIONS     *****************************


	public void TakeFromGM(int fish, int coin)
	{
		this.CoinsTotal = coin;
		this.fishCount = fish;
	}

	//***********************************COIN OPERATIONS***********************************
	//Getters
	public int GetTotalCoinCount() { return CoinsTotal; }    //Total Coin Count
	public int GetNewCoinCount() { return CoinsNew; }         //New Coins

	//Setter for when we pick up new coins
	public void AddToNewCoins(int Coins) { CoinsNew += Coins; }

	//End Of Level Operation: add new coins to total and reset new coin count
	public int AddUpAllCoins()
	{
		CoinsTotal += CoinsNew;     //add coins we've collected during adventure to total coins
		CoinsNew = 0;               //reset CoinsNew after adding it
        return CoinsTotal;
	}


	//if u die, you loose random amount between 20% - 60%
	//  expecting decimal 0.2 -> 0.6
	public void LostValue(float percentageValue)
	{
		float Coins = CoinsNew * percentageValue;
		CoinsNew = Mathf.FloorToInt(Coins);         //rounds to floow value 
	}


	//*********************************** FISH OPERATIONS ***********************************
	public int GetFishCount() { return fishCount; }          //Getter: Fish
	public void AddToFishCount() { fishCount++; }           //Setter: add to fish
	public void TakeFromFishCount() { fishCount--; }        //Setter: take from fish


	//***********************************INVENTORY OPERATIONS***********************************
	private void OnEnable()
	{
		Fish.onFishCollected += Add;    //Fish Listener [+]
		Coin.OnCoinCollected += Add;    //Coin Listener [+]
	}
	private void OnDisable()
	{
		Fish.onFishCollected -= Add;    //Fish Listener [-]
		Coin.OnCoinCollected -= Add;    //Coin Listener [-]
	}

	//On Collection of item into inventory
	public void Add(ItemData itemData)
	{
		if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
		{
			item.AddToStack();
			OnInventoryChange?.Invoke(inventory);
		}    //if we have it, add to stack
		else
		{                                                      //if we don't have it
			InventoryItem newItem = new InventoryItem(itemData);    //  - create new inventory item
			inventory.Add(newItem);                                 //  - add to inventory list
			itemDictionary.Add(itemData, newItem);                  //  - add to dictionary so we can stack
			OnInventoryChange?.Invoke(inventory);
		}
	}

	//On Removal of item from inventory
	public void Remove(ItemData itemData)
	{
		if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
		{
			item.RemoveFromStack();     //decrement from stack number
			if (item.stackSize == 0)
			{              //if that makes our stack equal to zero
				inventory.Remove(item);             //  - remove item from inventory list
				itemDictionary.Remove(itemData);    //  - remove from dictionsary
				OnInventoryChange?.Invoke(inventory);
			}
		}
	}

}
