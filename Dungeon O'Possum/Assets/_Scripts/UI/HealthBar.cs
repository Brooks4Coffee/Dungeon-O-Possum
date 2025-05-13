using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Tutorial Used: https://www.youtube.com/watch?v=yxzg8jswZ8A&t=577s
public class HealthBar : MonoBehaviour  {

    [SerializeField] Health PlayerHealth;
    [SerializeField] Image totalHealthBar; 
    [SerializeField] Image currentHealthBar; 


    void Start()  {        
        //we divide by 100 to give us the decimal value for our fill amount. Eg, if we have 100, then we fill to 1 (100%)
        currentHealthBar.fillAmount = PlayerHealth.GetCurrentHealth() / 100;
    }

    void Update()  {
        currentHealthBar.fillAmount = PlayerHealth.GetCurrentHealth() / 100;
    }
}
