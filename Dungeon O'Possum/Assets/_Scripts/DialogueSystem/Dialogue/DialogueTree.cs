using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTree : MonoBehaviour   {
    [SerializeField] TextMeshProUGUI dialogueText; 
    [SerializeField] public List<Button> choiceButtons;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] DialogueLeaf.DialogueNode currentNode;


    void Awake() {
        dialoguePanel.SetActive(false);
    }


    public void StartDialogue(DialogueLeaf DialogueLeaf) {
        dialoguePanel.SetActive(true);
        SetDialogue(DialogueLeaf.startingNode);
    }


    public void SetDialogue(DialogueLeaf.DialogueNode node)   {
        currentNode = node;
        dialogueText.text = currentNode.dialogueText;


        for (int i = 0; i < choiceButtons.Count; i++)   { 
            if (i < currentNode.choices.Count)   {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<Text>().text = currentNode.choices[i].choiceText;
                int choiceIndex = i; // Local copy to avoid closure issue
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(choiceIndex));
            }
            else {  choiceButtons[i].gameObject.SetActive(false); }
        }
    }



    public void OnChoiceSelected(int choiceIndex)   {
        DialogueLeaf.DialogueNode nextNode = currentNode.choices[choiceIndex].nextNode;
        if (nextNode != null)  {  SetDialogue(nextNode);  }
        else {   EndDialogue();   }
    }



    public void EndDialogue() {  
        dialoguePanel.SetActive(false);  
    }
}

