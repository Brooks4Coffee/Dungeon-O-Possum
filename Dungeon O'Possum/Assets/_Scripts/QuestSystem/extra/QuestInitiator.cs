using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PossumObjectives; //has quest info, types of quests, and reward functions

/*
This script will be attached to objects (like the commission board at the adventurers' guild) for the player to begin quests made via the QuestSO script.
It will send an event that the QuestManager script will be listening for to add this script to the player's currently active quests. 
It also handles the UI part of the commissions board or emotes around sprites indicating they have a quest for the player. 

To Do: 
    -> Attach it to object, tell sprite of object to have a "!" emote 
    -> Make event stuff
    -> UI stuff when a quest is initiated
    -> Figure out how to attach dialogue scripts
    -> Sound effect for initiating quest
    ->     
*/



public class QuestInitiator : MonoBehaviour  {
    
    //TODO: Event thing


    [Header("Quest Progression States:")]
    [SerializeField] QuestState questState;


    [Header("GameObject Attach To This:")]
    [SerializeField] GameObject gameObj;    //can be commission board or character
    //TODO: Event thing to tell sprite to have emote here? 
    //TODO: Dialogue thing

    [Header("Quest UI Elements:")]   //this is mostly for commission board
    [SerializeField] TextMeshProUGUI QuestName;  
    [SerializeField] TextMeshProUGUI QuestDesc; 
    [SerializeField] TextMeshProUGUI QuestPay;
    [SerializeField] TextMeshProUGUI QuestXP; 
    

}