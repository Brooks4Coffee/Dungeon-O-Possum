using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Tutorial Used: https://youtu.be/1198z5dDc8g?si=PKOkXnhxBgJXNVOD
public class DialogueActivator : MonoBehaviour {
    
    //TODO: Event stuff here



    [Header("Lines Spoken")]
    [SerializeField] DialogueWriter[] dialogueLines; //array of dialogue said by characters

    [Header("Events in Dialogue")]
    [SerializeField] MovementEvent[] movements;     //array of movement events
    [SerializeField] TextEvent[] texts;             //array of text events
    
    //Trigger Dialogue 
    void OnTriggerEnter2D(Collider2D other)   {
        if (other.CompareTag("Player")) {
            //trigger event to call Dialogue manager
        }
    }
}
