using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestBoard : MonoBehaviour   {

    [Header("Pause Effect")]
    [SerializeField] bool GameIsPaused = false; //bool - is game paused? 

    [Header("Trackers")]
    public bool playerIsInteractable; //bool - is player in collider? 

    [Header("UI:")]
    [SerializeField] GameObject QuestMenu;      // UI - Quest Menu
    [SerializeField] GameObject InteractPrompt; // UI - Interact Prompt

    [Header("Quests Available List")]
    [SerializeField] List<Quests> AvailableQuests; //List of ShopItems this shop sells 

    [Header("Quests UI: Text ")]
    [SerializeField] Text  AvailableQuestsText;    //Text for ShopItems




    //On start: make sure everything isn't showing since we won't be near it...
    void Awake() {
        QuestMenu.SetActive(false);
        InteractPrompt.SetActive(false);
        playerIsInteractable = false; 
    }

    //Check for interaction
    void Update() {
        if ((Input.GetKey(KeyCode.F)) && (playerIsInteractable)) {      // if player interacts: 
            if (AvailableQuests.Count == 0) {
                
                return; 
            }
            Pause();                                                    //  - pause game (unpaused via button)
            InteractPrompt.SetActive(false);                            //  - take down prompt from HUD
            QuestMenu.SetActive(true);                                  //  - show Leave question
        }
    }

    //When entering Collider Space -> turn on interact prompt and spawn particles
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Take On Quest?"); 
            playerIsInteractable = true; 
            InteractPrompt.SetActive(true); //show prompt to interact
        }
    }
    
    //When leaving Collider Space -> turn off interact prompt
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsInteractable = false;
            try  {  InteractPrompt.SetActive(false); }    //hide prompt for interacting
            catch (Exception) { /*Something went wrong or its already false*/ }
        }
    }

    //Pauses game
    public void Pause() {
        Time.timeScale = 0.0f; 
        GameIsPaused = true; 
    }

    //Resumes game
    public void Resume() {
        Time.timeScale = 1.0f; 
        GameIsPaused = false;
    }

    //Getter for paused state:
    public bool GetPauseState() { return GameIsPaused; }
    
   
}

[System.Serializable]
public class Quests  {
    [SerializeField] public string QuestName;       //Name/Title of quest
    [SerializeField] public string instructions;    //Information about the quest below the title
    [SerializeField] public int bounty;             //number of coins recieved on completion
    //TODO: Make a quest mechanic
    //TODO: make a few basic quests
    //TODO: Implement a quest generator
}