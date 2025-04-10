using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
//he didn't go over this one too well either, just showing basics on video and github link. I studied and implemented it
public class DialogueDriver : MonoBehaviour  {
    [SerializeField] DialogueChannel dialogueChannel;
    [SerializeField] FlowChannel flowChannel;
    [SerializeField] FlowState dialogueState;

    DialogueSequencer dialogueSequencer;
    FlowState cachedFlowState;


    //bunch of event stufff
    void Awake()  {
        dialogueSequencer = new DialogueSequencer();
        dialogueSequencer.OnDialogueStart += OnDialogueStart;
        dialogueSequencer.OnDialogueEnd += OnDialogueEnd;
        dialogueSequencer.OnDialogueNodeStart += dialogueChannel.RaiseDialogueNodeStart;
        dialogueSequencer.OnDialogueNodeEnd += dialogueChannel.RaiseDialogueNodeEnd;
        dialogueChannel.OnDialogueRequested += dialogueSequencer.StartDialogue;
        dialogueChannel.OnDialogueNodeRequested += dialogueSequencer.StartDialogueNode;
    }



    void OnDestroy()  {
        dialogueChannel.OnDialogueNodeRequested -= dialogueSequencer.StartDialogueNode;
        dialogueChannel.OnDialogueRequested -= dialogueSequencer.StartDialogue;

        dialogueSequencer.OnDialogueNodeEnd -= dialogueChannel.RaiseDialogueNodeEnd;
        dialogueSequencer.OnDialogueNodeStart -= dialogueChannel.RaiseDialogueNodeStart;
        dialogueSequencer.OnDialogueEnd -= OnDialogueEnd;
        dialogueSequencer.OnDialogueStart -= OnDialogueStart;

        dialogueSequencer = null;
    }


    void OnDialogueStart(Dialogue dialogue)   {
        dialogueChannel.RaiseDialogueStart(dialogue);

        cachedFlowState = FlowStateMachine.Instance.CurrentState;
        flowChannel.RaiseFlowStateRequest(dialogueState);
    }


    private void OnDialogueEnd(Dialogue dialogue)  {
        flowChannel.RaiseFlowStateRequest(cachedFlowState);
        cachedFlowState = null;
        dialogueChannel.RaiseDialogueEnd(dialogue);
    }
}
