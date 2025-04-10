using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject   {

    [SerializeField] private DialogueNode firstNode;            //reference to first node
    [SerializeField]public DialogueNode FirstNode => firstNode;
}
