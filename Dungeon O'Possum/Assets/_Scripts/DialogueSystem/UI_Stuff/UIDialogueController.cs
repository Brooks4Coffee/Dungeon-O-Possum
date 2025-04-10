using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
//he didn't go over this one too well either, just showing basics on video and github link. I studied and implemented it
public class UIDialogueController : MonoBehaviour, DialogueNodeVisitor  {
    [Header("UI References")]
    [SerializeField] TextMeshProUGUI speakerText;                   //character name 
    [SerializeField] TextMeshProUGUI dialogueText;                  //what the character is saying

    [Header("Player's Choices")]
    [SerializeField] RectTransform choicesBoxTransform;             //Player's choices depending on dialogue position
    [SerializeField] UIChoiceController choiceControllerPrefab;     //other script reference that handles it

    [Header("Dialogue Channel Reference")]
    [SerializeField] DialogueChannel dialogueChannel;               //reference to the dialogue channel so we can work with events

    bool listenToInput = false;                                     //whether the player can select a choice at the moment
    DialogueNode nextNode = null;                                   //next part in script


    //obiously, on awake, we aren't just talking to people, so it all has to be inactive. and we have to set up our events
    private void Awake() {
        dialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        dialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        gameObject.SetActive(false);
        choicesBoxTransform.gameObject.SetActive(false);
    }


    //basically tell system to listen for player to press 'continue' 
    void Update() { if (listenToInput && Input.GetButtonDown("Submit"))  { dialogueChannel.RaiseRequestDialogueNode(nextNode);  } }


    //on each nodes start, set it to active and show the dialogue line and speaker's name
    void OnDialogueNodeStart(DialogueNode node)   {
        gameObject.SetActive(true);
        dialogueText.text = node.DialogueLine.Text;
        speakerText.text = node.DialogueLine.Speaker.CharacterName;
        node.Accept(this);
    }


    //tells UI to listen for player chioce and sets the next node reference for it
    public void Visit(BasicDialogueNode node)  {
        listenToInput = true;
        nextNode = node.NextNode;
    }


    //this is basically showing our player choices if there are any
    public void Visit(ChoiceDialogueNode node)  {
        choicesBoxTransform.gameObject.SetActive(true);
        foreach (DialogueChoice choice in node.Choices)    {
            UIChoiceController newChoice = Instantiate(choiceControllerPrefab, choicesBoxTransform);
            newChoice.Choice = choice;
        }
    }


    //When dialogue node is done displaying, we turn it off and destroy any child objects
    void OnDialogueNodeEnd(DialogueNode node) {
        nextNode = null;                //take off next reference
        listenToInput = false;          //done with interactions
        dialogueText.text = "";         //clear dialogue lines
        speakerText.text = "";        //clear name of speaker

        //destroy child objects
        foreach (Transform child in choicesBoxTransform) { Destroy(child.gameObject); }
        
        //set everything to inactive state
        gameObject.SetActive(false);
        choicesBoxTransform.gameObject.SetActive(false);
    }

    //when this gameobject is destroyed, trigger events in dialogue channel
    void OnDestroy()  {
        dialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        dialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }
}