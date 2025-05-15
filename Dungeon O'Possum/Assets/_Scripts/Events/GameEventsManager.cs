using System;
using UnityEngine;

//https://github.com/shapedbyrainstudios/quest-system/blob/4-dialogue-implemented/Assets/Scripts/Events/GameEventsManager.cs 
public class GameEventsManager : MonoBehaviour  {


    
    //
    public static GameEventsManager instance { get; private set; }

    // public InputEvents inputEvents;
    // public PlayerEvents playerEvents;
    // public GoldEvents goldEvents;
    // public MiscEvents miscEvents;
    public QuestEvents questEvents;
    // public DialogueEvents dialogueEvents;



    private void Awake()   {
        if (instance != null)  {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }

        instance = this;

        // initialize all events
        // inputEvents = new InputEvents();
        // playerEvents = new PlayerEvents();
        // goldEvents = new GoldEvents();
        // miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
        // dialogueEvents = new DialogueEvents();
    }
}