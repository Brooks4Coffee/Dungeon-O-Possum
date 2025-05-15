using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
    To Add: 
        -> Visual Effects (screen shake for angry, Emotes to go over portraits, emotes to go over sprites, fade to black for end chapter or whatever, etc)
        -> Sound Effects ("voices", something also like Ace Attorney, etc)
        -> Art for Sprites and portraits
        -> Animations + Hook up animators 
*/



//Tutorial Used: https://youtu.be/1198z5dDc8g?si=PKOkXnhxBgJXNVOD
public class DialogueManager : MonoBehaviour  {

    [Header("Interaction stuff:")]
    //  - Character Library -> Cutscene System (Character library) (C# Script)??
    [SerializeField] bool IsPerson;     // Is our character talking to a Person or interacting with something?


    [Header("Dialogue Info:")]
    [SerializeField] bool InDialogue;               // Is In Dialogue
    [SerializeField] DialogueActivator dialogue;    // Lines To Display 
    [SerializeField] int currentLine = -1;          // Current Line
    //  - Text Info (Has Integer and Drop Down)


    //[Header("Basic Dialogue UI:")]
    [SerializeField] GameObject dialogueBox;            // Dialogue Box
    [SerializeField] TextMeshProUGUI currentText;       // Current Text 
    [SerializeField] TextMeshProUGUI  currentNameText;  // Current Name Text
    [SerializeField] Image portraitImage;               // Portrait Image (Image)
     // Portrait Animation (Animator)
     // Portrait FX Animation (Animator)


    [Header("Dialogue Options:")]
    [SerializeField] Button optionBox1;             // Option Box #1 
    [SerializeField] Button optionBox2;             // Option Box #2 
    [SerializeField] Button optionBox3;             // Option Box #3 
    [SerializeField] Button nextButton;             // Next/Continue Button 
    [SerializeField] TextMeshProUGUI optionText1;   // Option Text #1 
    [SerializeField] TextMeshProUGUI optionText2;   // Option Text #2 
    [SerializeField] TextMeshProUGUI optionText3;   // Option Text #3 
    [SerializeField] bool optionSelected;           // Option has been Selected


    [Header("Other Stuff:")]
    [SerializeField] GameObject Camera;             // Camera Object
    [SerializeField] GameObject VignetteSprite;     // Vignetted Sprite 
    [SerializeField] int ActorMoveSpeed;            // Actor Move Speed
    [SerializeField] bool eventOver;                // Event Over


    [Header("Character Voices:")]
    [SerializeField] bool lowVoice;         // Speaking quietly
    [SerializeField] bool normalVoice;      // Speaking normally
    [SerializeField] bool LoudVoice;        // Speaking loudly
    


    //CHARACTER CHECK: 
    //boolean values for all characters
    //eg:  - Is O'Possum (Boolean)


    //TODO: Function -> Start Dialogue (calls Show Dialogue)

    //TODO: Function -> Show Current Line

    //TODO: Function -> Next Line

    //TODO: Function -> Show Dialogue (UI stuff)

    //TODO: Function -> Hide Dialogue (UI stuff)

    //TODO: Function -> Option Chosen (skipping around the dialogue based on player choice)
}
