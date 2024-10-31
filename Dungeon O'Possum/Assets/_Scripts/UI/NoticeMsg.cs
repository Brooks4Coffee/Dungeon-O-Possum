using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoticeMsg : MonoBehaviour  {
    [SerializeField] TextMeshProUGUI text;

    
    /*
     * 
     */
    void Start()  {
        HideText();
    }

    /*
     * 
     */
    public void ShowText()  {
        text.gameObject.SetActive(true);
    }

    /*
     * 
     */
    public void HideText(){
        text.gameObject.SetActive(false);
    }
}
