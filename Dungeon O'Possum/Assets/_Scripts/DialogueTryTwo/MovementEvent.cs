using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEvent : MonoBehaviour  {

    [Header("Are Any Actors Moving Here?")]
    [SerializeField] bool IsMovementEvent;  

    [Header("Actors on Set:")]
    [SerializeField] Actor[] actors; //Actors in scene

    
    //SETTERS:================================================
    //TODO: get this set up


    //GETTERS:================================================
    public bool getIsMovement() { return IsMovementEvent; }
    public Actor[] getActors() { return actors; }


}