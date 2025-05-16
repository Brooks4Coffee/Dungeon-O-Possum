using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour  {

    [SerializeField] Inventory inventory;   //Inventory holds how many we have + how many we collected
    [SerializeField] TextMeshProUGUI coinText;      //used to update text


    /*
     * this will update our tally on screen (upper right) to show how many asteroids we've shot down
     */
    void Update()  {
        coinText.text = inventory.GetTotalCoinCount().ToString();
    }
}