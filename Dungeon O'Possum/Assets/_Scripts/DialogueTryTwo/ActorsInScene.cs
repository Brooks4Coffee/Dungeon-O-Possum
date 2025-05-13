using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Dial2/ActorsInScene")]
public class ActorsInScene : ScriptableObject  {

    [Header("Current Positions:")]
    [SerializeField] Position[] positions; // Positions 

    [Header("Actors on Set:")]
    [SerializeField] Actor[] actors; //Actors in scene


    //SETTERS:================================================
    //TODO: get this set up


    //GETTERS:================================================
    public Position[] getPositions() { return positions; }
    public Actor[] getActors() { return actors; }
}