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
    [SerializeField] bool Do_We_Want_Particles;

    [Header("UI:")]
    [SerializeField] GameObject LeaveMenu;       // UI - Leave area Menu
    [SerializeField] NoticeMsg InteractPrompt;  // UI - Interact Prompt
    [SerializeField] string toPrompt;
    
    [Header("Particle Systems:")]
    [SerializeField] ParticleSystem PS_PlayerIsNear;     //particle system prefab
    [SerializeField] ParticleSystem PS_GiveBlessings;    //particle system prefab
    private ParticleSystem PS_PlayerIsNearInstance;     //instances of particle systems:     
    private ParticleSystem PS_GiveBlessingsInstance;    //instances of particle systems:



    void Awake() {
        LeaveMenu.SetActive(false);
        InteractPrompt.HideText();    //  - take down prompt from HUD
        playerIsInteractable = false; 
    }


    void Update() {
        if ((Input.GetKey(KeyCode.F)) && (playerIsInteractable)) {          //if player interacts: 
            Pause();                            //  - pause game (unpaused via button)
            InteractPrompt.HideText();    //  - take down prompt from HUD
            LeaveMenu.SetActive(true);          //  - show Leave question
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsInteractable = true; 
            InteractPrompt.ShowText(toPrompt);
            if (Do_We_Want_Particles) {   SpawnPlayerIsNearParticles();     }   //spawn player is near particles
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsInteractable = false; 
            InteractPrompt.HideText();
           // try  {  InteractPrompt.HideText(); }
           // catch (Exception) { /*Something went wrong or its already false*/ }
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
        Destroy(PS_PlayerIsNearInstance.gameObject, 5); //ensures it goes away
    }
}
