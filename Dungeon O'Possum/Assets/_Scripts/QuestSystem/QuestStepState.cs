using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestStepState  {

    [SerializeField] public string state;
    [SerializeField] public string status;


    public QuestStepState(string state, string status)  {
        this.state = state;
        this.status = status;
    }


    public QuestStepState()  {
        this.state = "";
        this.status = "";
    }
}