using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
public interface DialogueNodeVisitor   {

    void Visit(BasicDialogueNode node);     //basically saying 'continue'

    void Visit(ChoiceDialogueNode node);    //if we make a choice
}
