using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestBoard : Interact   {

    [Header("UI:")]
    [SerializeField] GameObject QuestMenu;      // UI - Quest Menu
    [SerializeField] QuestBoardManager qbmgr;



    //On start: make sure everything isn't showing since we won't be near it...
    void Awake() {
        QuestMenu.SetActive(false);
    }


    //Check for interaction
    void Update() {
        if ( CheckForInteraction() ) {                          // if player interacts: 
            int AvailableQuests = qbmgr.getAvailableQuests();   //   - 
            if ( AvailableQuests <= 0 ) {                       //   - Check if there's any quests available:  
                QuestMenu.SetActive(true);                      //      -> show quest menu
            } 
            else { 
                //TODO: tell player there's nothing available.  //      -> if no, tell player and leave
                return; 
            }
        }
    }
}
