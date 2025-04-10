using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Node/Basic")]
public class BasicDialogueNode : DialogueNode  {

    [SerializeField] private DialogueNode nextNode;
    [SerializeField] public DialogueNode NextNode => nextNode; //next node to play after this

    public override bool CanBeFollowedByNode(DialogueNode node)  { return nextNode == node;  }
    public override void Accept(DialogueNodeVisitor visitor)  {  visitor.Visit(this);  }
}
