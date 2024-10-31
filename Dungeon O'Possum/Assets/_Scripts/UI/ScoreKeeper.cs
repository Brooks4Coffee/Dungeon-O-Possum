using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour  {

    [Header("Inventory")]
    [SerializeField] Inventory inventory; 
    [SerializeField] TextMeshProUGUI coinText;      //used to update text
    [SerializeField] TextMeshProUGUI goodiesText;      //used to update text

    
    void Update()  {    //***NOTE TO SELF: may want to change this to only update when we pick something up
        //coinText.text = inventory.GetNewCoinCount().ToString();
        //goodiesText.text = inventory.GetGoodiesCount().ToString();
    }
}
