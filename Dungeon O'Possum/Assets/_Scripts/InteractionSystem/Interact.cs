using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public abstract class Interact : MonoBehaviour {

    [Header("Trackers")]
    [SerializeField] public bool playerIsInteractable;       //bool - is player in collider? 
    [SerializeField] bool GameIsPaused = false;              //bool - is game paused? 
    [SerializeField] bool isMiniGame;

    [Header("UI:")]
    [SerializeField] public GameObject DisplayMenu;          // UI - Leave area Menu
    [SerializeField] NoticeMsg prompt;              // UI - Notice msg
    [SerializeField] string toPrompt;               // UI - Notice msg text
    


    void Awake() {
        DisplayMenu.SetActive(false);
        playerIsInteractable = false;

        //Hide prompt text if it's open
        try  {  prompt.HideText(); }
        catch (Exception) { /*Something went wrong or its already false*/ }
    }


    public bool CheckForInteraction() {
        if (Input.GetKey(KeyCode.F) && playerIsInteractable) {   //if player interacts: 
            if (!isMiniGame) { 
                Pause(); 
                try  {  prompt.HideText(); }                         //  - Hide prompt text if it's open
                catch (Exception) { /*Something went wrong or its already false*/ }
            }                        //  - pause game (unpaused via button)
            DisplayMenu.SetActive(true);
            return true;
        }
        else { return false; }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            prompt.ShowText(toPrompt); //show prompt to interact
            playerIsInteractable = true; 
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
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
