using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used to pop up menu for leaving a scene
//  TODO:   - Update it to take over communicating with scene manager 
public class DoorInteraction : Interact  {
    [Header("Has player pressed 'F'?")]
    [SerializeField] bool PlayerInteracted;     //see if player has interacted

    [Header("Scene Movement Settings:")]
    [SerializeField] SceneMovement moveScene;   //script to move between scenes
    [SerializeField] string toScene;            //which scene do we want to go to?
    [SerializeField] Button leaveButton;        //player is going to next scene


    void Start()    {
        leaveButton.onClick.AddListener(GoToScene);
    }

    void Update() {
        PlayerInteracted = CheckForInteraction();
    }


    public void GoToScene() {
        moveScene.LeaveHere(toScene); 
    }
}
