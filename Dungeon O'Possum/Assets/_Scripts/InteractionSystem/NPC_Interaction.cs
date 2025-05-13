using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class NPC_Interaction : Interact  {

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
}

