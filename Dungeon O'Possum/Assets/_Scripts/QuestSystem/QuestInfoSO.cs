using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

*/

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "Quest/QuestInfoSO")]
public class QuestInfoSO : ScriptableObject  {

    [SerializeField] public string id { get; private set; } 

    [Header("General:")]
    [SerializeField] string displayName; 

    [Header("Requirements:")]
    [SerializeField] public int levelRequirement;              //level player needs to be to start quest
    [SerializeField] public QuestInfoSO[] questPrerequisites;  //What the player needs to have done before they can start this quest
    
    [Header("Quest Steps:")]
    [SerializeField] public GameObject[] questStepPrefabs;      //Array of tracked actions/the steps of the quest
    [SerializeField] int currentObjective = -1;          //Which step are we on


    [Header("Rewards:")]
    [SerializeField] int goldReward;
    [SerializeField] int XPReward;
    //[SerializeField] ItemData[] items;        //TODO: item rewards



    // ensure the id is always the name of the Scriptable Object asset
    private void OnValidate()  {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}