using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interact : MonoBehaviour {

    [Header("Trackers")]
    public bool playerIsInteractable; //bool - is player in collider? 
    [SerializeField] bool GameIsPaused = false; //bool - is game paused? 
    [SerializeField] bool isFishing = false;

    [Header("UI:")]
    [SerializeField] GameObject LeaveMenu;       // UI - Leave area Menu
    [SerializeField] NoticeMsg prompt; 
    [SerializeField] string toPrompt; 
    

    void Awake() {
        LeaveMenu.SetActive(false);
        playerIsInteractable = false; 
    }


    void Update() {
        if ((Input.GetKey(KeyCode.F)) && (playerIsInteractable)) {          //if player interacts: 
            if (!isFishing) { Pause(); }         //  - pause game (unpaused via button)
            prompt.HideText();
            LeaveMenu.SetActive(true);          //  - show Leave question
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Ready To Leave?"); 
            prompt.ShowText(toPrompt); //show prompt to interact
            playerIsInteractable = true; 
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Continue then..");   //hide prompt for interacting
            playerIsInteractable = false; 
            try  {  prompt.HideText(); }
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
