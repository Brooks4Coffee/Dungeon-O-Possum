using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Character")]
public class NarrationCharacter : ScriptableObject  {
    
    [SerializeField] private string characterName;                       //Who's speaking

    public string CharacterName => characterName; 

}
