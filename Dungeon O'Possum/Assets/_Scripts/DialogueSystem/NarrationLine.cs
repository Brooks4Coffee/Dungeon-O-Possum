using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Line")]
public class NarrationLine : ScriptableObject   {

    [SerializeField] private NarrationCharacter npcSpeaking;    //who's speaking
    [SerializeField] private string text;                       //what they're saying

    public NarrationCharacter Speaker => npcSpeaking; 
    public string Text => text; 
}
