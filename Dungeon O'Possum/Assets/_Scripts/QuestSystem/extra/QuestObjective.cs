using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PossumObjectives {

    /*********************************************************************
     QuestObjective: 
            -> 

    */
    [System.Serializable]
    public class QuestObjective {
        [Header("Quest Objective Info:")]
        [SerializeField] bool isCommission;     //is this from commission board or somewhere else? 
        [SerializeField] bool CompletedQuest;   //Are you done with this quest?        
        [SerializeField] string QuestTitle; 
        [SerializeField] string QuestDesc; 
        [SerializeField] QuestType questType;
        [SerializeField] int totalAmount;       //how many you need to gather/kill/talk to/etc
        [SerializeField] int currentAmount;     //how many you already have gathered/killed/talked to/ etc
        
        
        //SETTERS:===========================================================
        //TODO: set up the setters for later randomizer


        //GETTERS:===========================================================
        bool getIsCommision() { return isCommission; }
        bool getCompleted() { return CompletedQuest; }
        string getQuestName() { return QuestTitle; }
        string getQuestDesc() { return QuestDesc; }
        QuestType getQuestType() { return questType; }
        int getCurrentAmount() { return currentAmount; }
        int getTotalAmount() { return totalAmount; }
    }


    /*********************************************************************
     QuestRewards: 
            -> 

    */
    [System.Serializable]
    public class QuestRewards {
        [SerializeField] int QuestXP;           //XP you get for completion
        [SerializeField] ItemData[] QuestItems;  //Item(s) you get for completion
        

        
        //SETTERS:===========================================================
        //TODO: set up the setters for later randomizer


        //GETTERS:===========================================================
        int getQuestXP() { return QuestXP; }
        ItemData[] getQuestItems() { return QuestItems; }
        
        
        public void GiveRewards()   {
            //TODO: Reward player with XP and Items :D 
        }
    }


    /*********************************************************************
     Types of Quests: 
            -> Kill = kill monster type xyz or maybe a character? 
            -> Talk = talk to npc
            -> Gather = fish this many, get some random treasure, etc
            -> Destination = go here... self explainatory
            -> Investigate = interact with xyz object
    */
    public enum QuestType {
        KILL,
        TALK,
        GATHER, 
        DESTINATION,
        INVESTIGATE
    }
}