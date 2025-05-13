using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Blessings : MonoBehaviour  {
    [Header("Player:")]
    [SerializeField] Player player; 
    [SerializeField] PlayerCombat playerCombat; 
    [SerializeField] Health playerHealth; 
    [SerializeField] int blessingChoice; 

    [Header("Pause Effect")]
    [SerializeField] bool GameIsPaused = false;

    [Header("Level Configurations:")]
    [SerializeField] int maxBlessings = 1; 
    [SerializeField] int givenBlessings = 0; 

    [Header("UI:")]
    [SerializeField] GameObject blessingsMenu; 
    [SerializeField] GameObject InteractPrompt; 
    
    [Header("Particle Systems:")]
    [SerializeField] ParticleSystem PS_PlayerIsNear;
    [SerializeField] ParticleSystem PS_GiveBlessings;

    //instances of particle systems:
    private ParticleSystem PS_PlayerIsNearInstance; 
    private ParticleSystem PS_GiveBlessingsInstance;

    //other
    public bool playerIsInteractable; 
    public bool playerHasRecievedBlessings; 



    void Start() {
        playerIsInteractable = false; 
        playerHasRecievedBlessings = false;
        InteractPrompt.SetActive(false);
        blessingsMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetKey(KeyCode.F) && playerIsInteractable) {     
            if ((!playerHasRecievedBlessings) && givenBlessings != maxBlessings) {   //didn't work when put together with above checker
                Pause(); 
                InteractPrompt.SetActive(false); 
                blessingsMenu.SetActive(true); //show blessing options
                playerIsInteractable = false; 
            }
        }
    }

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("HELLO PLAYER :D"); 
            if (!playerHasRecievedBlessings) {
                InteractPrompt.SetActive(true); //show prompt to interact
            }
            playerIsInteractable = true; 
            SpawnPlayerIsNearParticles();
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("GOODBYE PLAYER :D"); //hide prompt for interacting
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
    
    //Choose blessings
    public void ChooseBlessings(int choice) {
        blessingChoice = choice; 
        givenBlessings++;                 
        playerHasRecievedBlessings = true;                              
        GiveBlessings(blessingChoice);
    }

    //Give Blessings
    void GiveBlessings(int blessingChoice) {
        givenBlessings++; 
        InteractPrompt.SetActive(false); 
        Resume();
        switch(blessingChoice) {
            case 1:
                player.SetWalkSpeed(1.25f);             //increase player's speed by 25%
                player.SetSprintSpeed(1.25f);
                break;
            case 2:
                playerHealth.BlessCurrentHealth(1); //add one heart to players health and heal them 
                break;
            case 3:
                playerCombat.BlessAttack(1.25f);    //increase player's attack by 25%
                break;
            default:
                break;
        }
    }



    /*
     * 
     */ 
    private void SpawnPlayerIsNearParticles() {
        PS_PlayerIsNearInstance = Instantiate(PS_PlayerIsNear, transform.position, Quaternion.identity); 
        Destroy(PS_PlayerIsNearInstance, 10); //ensures it goes away
    }

    /*
     * 
     */ 
    private void SpawnGiveBlessingsParticles() {
        PS_GiveBlessingsInstance = Instantiate(PS_GiveBlessings, transform.position, Quaternion.identity); 
        Destroy(PS_GiveBlessingsInstance, 10); //ensures it goes away
    }
}
