using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorials Used: https://www.youtube.com/watch?v=f75Wcwu33OY
//                https://www.youtube.com/watch?v=geq7lQSBDAE
public class Wood : MonoBehaviour, ICollectable  {
    
    public static event HandleWoodCollection onWoodCollected;                 //Event
    public delegate void HandleWoodCollection(ItemData item);    //delegate 
    public ItemData woodData;                                   //reference

    public void Collect() {
        //Debug.Log("You've Collected Woods");
        Destroy(gameObject);
        onWoodCollected?.Invoke(woodData);
    }
}
