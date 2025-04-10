using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
public abstract class DialogueNode : ScriptableObject   {
    
    [SerializeField] private NarrationLine dialogueLine;
    [SerializeField] public NarrationLine DialogueLine => dialogueLine;


    public abstract bool CanBeFollowedByNode(DialogueNode node);         //aka, the next sentence
    public abstract void Accept(DialogueNodeVisitor visitor);       //the choice the player made
}
