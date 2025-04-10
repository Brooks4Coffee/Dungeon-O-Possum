using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
 * he didn't go over this one too well either, just showing basics on video and github link. I studied and implemented it
 * luckily, not my first time working with events
*/
[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Dialogue Channel")]
public class DialogueChannel : ScriptableObject
{
    public delegate void DialogueCallback(Dialogue dialogue);
    public DialogueCallback OnDialogueRequested;
    public DialogueCallback OnDialogueStart;
    public DialogueCallback OnDialogueEnd;

    public delegate void DialogueNodeCallback(DialogueNode node);
    public DialogueNodeCallback OnDialogueNodeRequested;
    public DialogueNodeCallback OnDialogueNodeStart;
    public DialogueNodeCallback OnDialogueNodeEnd;



    //Request Dialogue Event
    public void RaiseRequestDialogue(Dialogue dialogue) {
        OnDialogueRequested?.Invoke(dialogue);
    }


    //Request Dialogue Start Event
    public void RaiseDialogueStart(Dialogue dialogue)  {
        OnDialogueStart?.Invoke(dialogue);
    }


    //Request Dialogue End Event
    public void RaiseDialogueEnd(Dialogue dialogue)  {
        OnDialogueEnd?.Invoke(dialogue);
    }


    //Request Dialogue Node Event
    public void RaiseRequestDialogueNode(DialogueNode node)  {
        OnDialogueNodeRequested?.Invoke(node);
    }


    //Request Dialogue Node Start Event
    public void RaiseDialogueNodeStart(DialogueNode node)  {
        OnDialogueNodeStart?.Invoke(node);
    }


    //Request Dialogue node End Event
    public void RaiseDialogueNodeEnd(DialogueNode node) {
        OnDialogueNodeEnd?.Invoke(node);
    }
}
