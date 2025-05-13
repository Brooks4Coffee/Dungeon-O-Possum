using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Tutorial Used: https://youtu.be/1198z5dDc8g?si=PKOkXnhxBgJXNVOD
[CreateAssetMenu(fileName = "Dial2/DialogueWriter")]
public class DialogueWriter : ScriptableObject   {
    [SerializeField] TextMeshProUGUI LineText;
    [SerializeField] TextMeshProUGUI CharacterToShow; 
    [SerializeField] Image Portrait; 
    //[SerializeField] some array of emotion portraits this character can display;
    //[SerializeField] choices[]
    //[SerializeField] tags/events
}
