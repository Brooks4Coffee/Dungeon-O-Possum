using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Exit : MonoBehaviour  {

    [Header("Pause Effect")]
    [SerializeField] bool GameIsPaused = false; //bool - is game paused? 

    [Header("Trackers")]
    public bool playerIsInteractable; //bool - is player in collider? 

    [Header("UI:")]
    [SerializeField] GameObject LeaveMenu;       // UI - Leave area Menu
    [SerializeField] GameObject InteractPrompt;  // UI - Interact Prompt
    
    [Header("Particle Systems:")]
    [SerializeField] ParticleSystem PS_PlayerIsNear;     //particle system prefab
    [SerializeField] ParticleSystem PS_GiveBlessings;    //particle system prefab
    private ParticleSystem PS_PlayerIsNearInstance;     //instances of particle systems:     
    private ParticleSystem PS_GiveBlessingsInstance;    //instances of particle systems:



    void Awake() {
        LeaveMenu.SetActive(false);
        InteractPrompt.SetActive(false);
        playerIsInteractable = false; 
    }


    void Update() {
        if ((Input.GetKey(KeyCode.F)) && (playerIsInteractable)) {          //if player interacts: 
            Pause();                            //  - pause game (unpaused via button)
            InteractPrompt.SetActive(false);    //  - take down prompt from HUD
            LeaveMenu.SetActive(true);          //  - show Leave question
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Ready To Leave?"); 
            InteractPrompt.SetActive(true); //show prompt to interact
            playerIsInteractable = true; 
            SpawnPlayerIsNearParticles();   //spawn player is near particles
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Continue then..");   //hide prompt for interacting
            playerIsInteractable = false; 
            try  {  InteractPrompt.SetActive(false); }
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
    
    
    // spawns a particle system 
    private void SpawnPlayerIsNearParticles() {
        PS_PlayerIsNearInstance = Instantiate(PS_PlayerIsNear, transform.position, Quaternion.identity); 
        Destroy(PS_PlayerIsNearInstance, 5); //ensures it goes away
    }
}
