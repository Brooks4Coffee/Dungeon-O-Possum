using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class NPC_Interaction : MonoBehaviour  {

    [Header("Pause Effect")]
    [SerializeField] bool GameIsPaused = false; //bool - is game paused? 

    [Header("Trackers")]
    public bool playerIsInteractable; //bool - is player in collider? 

    [Header("UI:")]
    [SerializeField] GameObject NPCDialogue;        // UI - NPC Dialogue thing
    [SerializeField] GameObject InteractPrompt;     // UI - Interact Prompt

    [Header("NPC Info:")]
    [SerializeField] string NPCname = "d";           



    //On start: make sure everything isn't showing since we won't be near it...
    void Awake() {
        try  {  InteractPrompt.SetActive(false); }    //hide prompt for interacting
        catch (Exception) { /*Something went wrong or its already false*/ }
        
        try  {  NPCDialogue.SetActive(false); }    //hide prompt for interacting
        catch (Exception) { /*Something went wrong or its already false*/ }

    }

    //Check for interaction
    void Update() {
        if ((Input.GetKey(KeyCode.F)) && (playerIsInteractable)) {      // if player interacts: 
            Pause();                                                    //  - pause game (unpaused via button)
            InteractPrompt.SetActive(false);                            //  - take down prompt from HUD
            NPCDialogue.SetActive(true);                                  //  - show Leave question
        }
    }

    //When entering Collider Space -> turn on interact prompt and spawn particles
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Talk to " + NPCname + "?"); 
            playerIsInteractable = true; 
            InteractPrompt.SetActive(true); //show prompt to interact
        }
    }
    
    //When leaving Collider Space -> turn off interact prompt
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            //Debug.Log("Continue then..");
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

