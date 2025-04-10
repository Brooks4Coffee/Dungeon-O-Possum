using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepStuffOnLoad : MonoBehaviour  {

    public static KeepStuffOnLoad instance;

    void Awake(){
        if (instance == null) { instance = this;}
        else { Destroy(this.gameObject); }
        DontDestroyOnLoad(gameObject);
    }
    

    void Start()  {
        
    }



    void Update()  {
        
    }
}
