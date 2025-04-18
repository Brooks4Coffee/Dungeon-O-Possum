using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class DialogueChoice  {

    [SerializeField] private string choicePreview;
    [SerializeField] private DialogueNode choiceNode;

    public string ChoicePreview => choicePreview;
    public DialogueNode ChoiceNode => choiceNode;
}




[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Node/Choice")]
public class ChoiceDialogueNode : DialogueNode  {

    [SerializeField]  private DialogueChoice[] choices;
    [SerializeField]  public DialogueChoice[] Choices => choices;


    public override bool CanBeFollowedByNode(DialogueNode node)  {return choices.Any(x => x.ChoiceNode == node);  }
    public override void Accept(DialogueNodeVisitor visitor)  { visitor.Visit(this);  }
}