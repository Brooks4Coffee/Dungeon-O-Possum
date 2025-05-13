using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to pop up menu for mini games
//  TODO:   - Update it to take over the communication with player being in a mini-game 
public class MiniGameInteract : Interact   {
    [SerializeField] bool PlayerInteracted;

    void Update() {
        PlayerInteracted = CheckForInteraction();
    }
}
