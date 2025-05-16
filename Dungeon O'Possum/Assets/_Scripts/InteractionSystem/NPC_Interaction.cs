using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class NPC_Interaction : MonoBehaviour  {

    [Header("Game Manager:")]
    [SerializeField] GameManager gm;

    [Header("Trackers:")]
    [SerializeField] bool playerIsInteractable;       //bool - is player in collider? 
    [SerializeField] bool GameIsPaused = false;       //bool - is game paused?
    [SerializeField] bool isTalking;                 //bool - is character speaking? 

    [Header("User Interface:")]
    [SerializeField] NoticeMsg prompt;              // UI - Notice msg
    [SerializeField] string toPrompt;               // UI - Notice msg text
    [SerializeField] GameObject DialogueUI;         // UI - dialogue menu
    [SerializeField] NoticeMsg DialogueText;        // UI - dialogue txt spot
    [SerializeField] NoticeMsg NPC_NameUI;          //UI - name of character speaking

    [Header("NPC Info:")]
    [SerializeField] string NPC_name;
    //[SerializeField] Image NPC_portrait;

    [Header("NPC Dialogue:")]
    [SerializeField] public string[] dialogueLines;
    [SerializeField] int dialogueIndex = 0;



    //On start: make sure everything isn't showing since we won't be near it...
    void Awake()   {
        GameIsPaused = false;
        playerIsInteractable = false;
        try { DialogueUI.SetActive(false); }    //show panel for dialogue
        catch (Exception) { /*Something went wrong or its already false*/ }
        try { prompt.HideText(); }
        catch (Exception) { /*Something went wrong or its already false*/ }
    }



    //Check for interaction
    void Update()  {
        // If player interacts with NPC and hasn't started talking, start conversation
        if (playerIsInteractable && !isTalking && Input.GetKeyDown(KeyCode.F))  { 
            try { prompt.HideText(); }                         //  - Hide prompt text if it's open
            catch (Exception) { /*Something went wrong or its already false*/ }
            Pause();
            StartDialogue();
        }

        // if already talking, then advance dialogue to next step
        if (isTalking && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))) {
            ContinueDialogue();
        }
    }

    //this will be updated to something better
#region Game Manager Functions: -----------------------------------
    public void UpdateGM() {
        if (NPC_name == "Gramps") {  gm.talkedToGramps = true;  }
        else if (NPC_name == "BarKeep") { gm.talkedToBarkeep = true; }
    }

    public void CheckGM() {
        if ( NPC_name == "Gramps" && gm.talkedToGramps == true ) {
            dialogueIndex = dialogueLines.Length - 1;
        }
        if ( NPC_name == "BarKeep" && gm.talkedToBarkeep == true ) {
            dialogueIndex = dialogueLines.Length - 1;
        }
    }
#endregion    


#region Show/Hide UI: -----------------------------------
    //Start dialogue
    public void StartDialogue() {
        isTalking = true;                                       //set isTalking to true
        try { DialogueUI.SetActive(true); }                     //show panel for dialogue
        catch (Exception) { /*Something went wrong or its already false*/ }
        NPC_NameUI.ShowText(NPC_name);                          //show name of person talking
        DialogueText.ShowText(dialogueLines[dialogueIndex]);    //show dialogue 
    }
    
    //Continue dialogue
    public void ContinueDialogue() {
        dialogueIndex++; //increment this! 
        if (dialogueIndex < dialogueLines.Length) {               //if we haven't reached the end yet
            DialogueText.ShowText(dialogueLines[dialogueIndex]);//  - show next line
        }
        else { EndDialogue(); } //else, end conversation...
    }


    //end dialogue and reset text on screen
    void EndDialogue()    {
        dialogueIndex = dialogueLines.Length - 1;   //that way we show the last thing said next time player tries to communicate...
        isTalking = false;
        UpdateGM();                                 //UPDATE GAME MANAGER!!!
        DialogueText.ShowText("");
        NPC_NameUI.ShowText("");                          
        try { DialogueUI.SetActive(false); }        //show panel for dialogue
        catch (Exception) { /*Something went wrong or its already false*/ }
        Resume();
    }
#endregion    
    

#region Collider Triggers: -----------------------------------
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))   {
            prompt.ShowText(toPrompt); //show prompt to interact
            playerIsInteractable = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))   {
            playerIsInteractable = false; 
            try  {  prompt.HideText(); }
            catch (Exception) { /*Something went wrong or its already false*/ }
        }
    }
    #endregion


#region Time Functions: -----------------------------------
    //Pauses game
    public void Pause()    {
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    //Resumes game
    public void Resume() {
        Time.timeScale = 1.0f; 
        GameIsPaused = false;
    }
    #endregion

}

