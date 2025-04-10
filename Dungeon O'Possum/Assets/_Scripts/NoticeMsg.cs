using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoticeMsg : MonoBehaviour  {
    
    [SerializeField] TextMeshProUGUI text;  //our TextMeshPro reference
    [SerializeField] private string textToShow;

    //on Awake: hide Notice Text
    void Awake() { HideText(); }


    //Show Notice Text - and update text
    public void ShowText(string textToShow) {
        UpdateText(textToShow);             //update text
        text.gameObject.SetActive(true);    //set the reference to active state
    }
    

    //update what text will say
    public void UpdateText(string textToShow) { 
        this.textToShow = textToShow; 
        text.text = textToShow;
    }
    

    //Hide Notice Text
    public void HideText(){ text.gameObject.SetActive(false); }  //set the reference to inactive state
       
}