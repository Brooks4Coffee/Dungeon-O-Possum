using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
 * he didn't go over this too well, just showing basics on video and github link. I studied and implemented it
 * 
*/


//didn't totally understand this bit, except that it'll help handling the exceptions that might arise using DialogueSequencer 
public class DialogueException : System.Exception   {
    public DialogueException(string message)
        : base(message)
    {
    }
}

//Basically conducts all the switching between nodes
public class DialogueSequencer   {
    public delegate void DialogueCallback(Dialogue dialogue);       //event thing for dialogue
    public delegate void DialogueNodeCallback(DialogueNode node);   //event thing for nodes

    public DialogueCallback OnDialogueStart;
    public DialogueCallback OnDialogueEnd;
    public DialogueNodeCallback OnDialogueNodeStart; 
    public DialogueNodeCallback OnDialogueNodeEnd;

    private Dialogue m_CurrentDialogue;
    private DialogueNode m_CurrentNode;


    //Start Dialogue sequence :D
    public void StartDialogue(Dialogue dialogue)   {
        if (m_CurrentDialogue == null)   {
            m_CurrentDialogue = dialogue;
            OnDialogueStart?.Invoke(m_CurrentDialogue);
            StartDialogueNode(dialogue.FirstNode);
        }
        else   { throw new DialogueException("Can't start a dialogue when another is already running.");  }
    }


    //End Dialogue sequence
    public void EndDialogue(Dialogue dialogue)   {
        if (m_CurrentDialogue == dialogue)   {
            StopDialogueNode(m_CurrentNode);
            OnDialogueEnd?.Invoke(m_CurrentDialogue);
            m_CurrentDialogue = null;
        }
        else { throw new DialogueException("Trying to stop a dialogue that ins't running.");  }
    }


    //Returns whether we can start the dialogue yet
    private bool CanStartNode(DialogueNode node)  {
        return (m_CurrentNode == null || node == null || m_CurrentNode.CanBeFollowedByNode(node));
    }



    //Start Dialogue on next node
    public void StartDialogueNode(DialogueNode node)   {
        if (CanStartNode(node))   {
            StopDialogueNode(m_CurrentNode);
            m_CurrentNode = node;

            if (m_CurrentNode != null)  {  OnDialogueNodeStart?.Invoke(m_CurrentNode); }    //begin dialogue
            else  { EndDialogue(m_CurrentDialogue);  }                                      //end dialogue
        }
        else   { throw new DialogueException("Failed to start dialogue node.");  }  //throw exceptions just in case
    }


    //stop dialogue on this node
    private void StopDialogueNode(DialogueNode node)   {
        if (m_CurrentNode == node)   {
            OnDialogueNodeEnd?.Invoke(m_CurrentNode);   
            m_CurrentNode = null;
        }
        else { throw new DialogueException("Trying to stop a dialogue node that ins't running.");  }
    }
}
