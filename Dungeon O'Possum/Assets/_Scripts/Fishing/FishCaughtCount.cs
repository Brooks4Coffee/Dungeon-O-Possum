using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishCaughtCount : MonoBehaviour  {

    [Header("Inventory")]
    [SerializeField] Inventory inventory; 
    [SerializeField] NoticeMsg fishText;          //used to update text

    
    void CaughtFish()  {    //***NOTE TO SELF: may want to change this to only update when we pick something up
        fishText.ShowText("You've caught: " + inventory.GetFishCount().ToString() + " Fish!");
        StartCoroutine(DelayHideTxt());   //start Coroutine
    }
    IEnumerator DelayHideTxt() {
        yield return new WaitForSeconds(3.0f);
        fishText.HideText(); 
        yield return null; 
    }  
}
