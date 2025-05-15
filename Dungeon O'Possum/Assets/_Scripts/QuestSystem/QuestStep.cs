using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial: https://www.youtube.com/watch?v=UyTJLDGcT64&list=PL3viUl9h9k7-oX3Sz8VvyKCIN24XOXNZR&index=3 
public abstract class QuestStep : MonoBehaviour  {

    [SerializeField] private bool isFinished = false;
    [SerializeField] private string questId;
    [SerializeField] private int stepIndex;  


    //
    public void InitializeQuestStep(string questId, int stepIndex, string questStepState) {
        this.questId = questId;
        this.stepIndex = stepIndex;

        if ((questStepState != null) && (questStepState != "")) {
            SetQuestStepState(questStepState);
        }
    }


    //
    protected void FinishQuestStep() {
        if (isFinished == false) {
            isFinished = true; 
            GameEventsManager.instance.questEvents.AdvanceQuest(questId);
            Destroy(this.gameObject);
        }
    }


    //
    protected void ChangeQuestState(string newState, string newStatus) {
        GameEventsManager.instance.questEvents.QuestStepStateChange(
            questId, 
            stepIndex, 
            new QuestStepState(newState, newStatus)
        );
    }


    //
    protected abstract void SetQuestStepState(string state);
}
