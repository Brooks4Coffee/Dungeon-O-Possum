using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLeaf", menuName = "Dialogue/DialogueLeaf", order = 1)]
public class DialogueLeaf : ScriptableObject  {

    [System.Serializable]
    public class DialogueNode   {
        public string dialogueText;
        public List<Choice> choices;
    }

    [System.Serializable]
    public class Choice   {
        public string choiceText;
        public DialogueNode nextNode;
    }

    public DialogueNode startingNode;
}