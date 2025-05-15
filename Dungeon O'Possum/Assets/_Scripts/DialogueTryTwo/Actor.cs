using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dial2/Actor")]
public class Actor : ScriptableObject  {

    [Header("Actor in Question:")]
    [SerializeField] GameObject actor;      // Actor Game Object
    
    [Header("Positions in Scene:")]
    [SerializeField] Vector2 beginPos;      // Actor Start Position   
    [SerializeField] Vector2 endPos;        // Actor End Position     

    [Header("Does Actor Leave Scene?")]
    [SerializeField] bool leaveScene;       // Leave Scene 



    //SETTERS:================================================
    //TODO: get this set up



    //GETTERS:================================================
    public GameObject getActor() { return actor; }
    public Vector2 getBeginPos() { return beginPos; }
    public Vector2 getEndPos() { return endPos; }
    public bool getLeaveScene() { return leaveScene; }

    //in case we need individual x or y coordinates: 
    public float getBeginXPos() { return beginPos.x; }
    public float getBeginYPos() { return beginPos.y; }
    public float getEndXPos() { return endPos.x; }
    public float getEndYPos() { return endPos.y; }
}
