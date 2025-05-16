using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
The purpose of this script is store values between scenes so that data is not lost.

What's being tracked (so far):
    - inventory items (gold, fish)
    - player world position when entering a different scene, so they exit to same spot
    - whether NPCs have been talked to or not (bool)

TODO: 
    - Getters and Setters...

*/

public class GameManager : MonoBehaviour    {

    public static GameManager instance; //only get one of these

    [Header("Inventory Items:")]
    [SerializeField] int goldAmount;
    [SerializeField] int fishAmount;
    //eventually will include: quest items, other weapons, etc
    
    [Header("Player:")]
    [SerializeField] Player player;
    [SerializeField] GameObject playerGO; 

    [Header("Camera:")]
    [SerializeField] Camera mc; 

    [Header("Player Info:")]
    [SerializeField] PlayerState pt; 
    [SerializeField] public bool talkedToGramps;
    [SerializeField] public bool talkedToBarkeep; 
    [SerializeField] public bool CompletedQuest;            //will get implemented
    //eventually will include: level, health, statuses(poison or whatever), etc

    

    string sceneName;

    
    void Awake()    {
        if (instance == null) { instance = this; } //if no instances active, make this one the active one across all scenes
        else {
            Debug.Log("GameManager already exists, destroying dopleganger: " + gameObject.name);
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject); //prevents 'death'/reset of this game object when moving between scenes
        spawnPlayerHere();
    }

    public void spawnPlayerHere() {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        //Overworld:
        if (sceneName == "OverWorld") {
            awakenPlayer(); 
        }

        // //Adventure's Guild: 
        // if (sceneName == "AdventureGuild") {
        //     player.transform.position = new Vector2(-0.36f, -3.27f);
        //     mc.transform.position = new Vector2(-0.36f, -3.27f);
        // }

        // //Dungeon: 
        // if (sceneName == "Dungeon") {
        //     player.transform.position = new Vector2(-32.51f, 30.05f);
        //     mc.transform.position = new Vector2(-32.51f, 30.05f);
        // }        
    }

    void awakenPlayer() {
        if (PlayerState.instance && PlayerState.instance.lastWorldPosition != Vector2.zero){
            player.transform.position = PlayerState.instance.lastWorldPosition;
            mc.transform.position = PlayerState.instance.lastWorldPosition;
        }
    }


    //"Setters"
    public void addGold(int gold) {  this.goldAmount += gold;  }
    public void addFish(int fish) {  this.fishAmount += fish;  }

    //Getters
    public int getGold() {  return goldAmount;  }
    public int getFish() {  return fishAmount;  }


    void OnEnable()   { SceneManager.sceneLoaded += OnSceneLoaded;   }
    void OnDisable()  {  SceneManager.sceneLoaded -= OnSceneLoaded;  }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)  {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        player = playerGO.GetComponent<Player>();
    }
}
