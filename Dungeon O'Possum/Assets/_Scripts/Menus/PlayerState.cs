using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour    {

    public static PlayerState instance;

    [Header("Player:")]
    [SerializeField] Player player;
    [SerializeField] public Vector2 lastWorldPosition; 




    void Awake()    {
        if (instance == null) { instance = this; } //if no instances active, make this one the active one across all scenes
        else {
            Debug.Log("PlayerState already exists, destroying dopleganger: " + gameObject.name);
            Destroy(gameObject); 
        }
    }


    //World Position: Getter + Setter
    public void storeWorldPos(Vector2 worldPos) { this.lastWorldPosition = worldPos; } 
    public Vector2 getWorldPos() {  return lastWorldPosition; }


}
