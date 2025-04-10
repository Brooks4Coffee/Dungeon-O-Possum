using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
//he didn't go over this one too well either, just showing basics on video and github link. I studied and implemented it
public class UIChoiceController : MonoBehaviour  {
    [SerializeField] TextMeshProUGUI choice;
    [SerializeField] DialogueChannel dialogueChannel;

    DialogueNode choiceNextNode;

    //A 'Setter' of sorts
    public DialogueChoice Choice  {
        set {
            choice.text = value.ChoicePreview;
            choiceNextNode = value.ChoiceNode;
        }
    }

    //Button Listener, make sure we're interactable
    private void Start()  {   GetComponent<Button>().onClick.AddListener(OnClick);  }

    //when player makes a choice (by clicking button), trigger event to get next dialogue node
    private void OnClick()  { dialogueChannel.RaiseRequestDialogueNode(choiceNextNode);  }
}
