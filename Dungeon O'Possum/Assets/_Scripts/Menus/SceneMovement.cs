using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour  {
    
    [Header("Screen Transition:")]   
    [SerializeField] ScreenTransition_Fading screenTransition;

    [Header("Scene Names:")]
    [SerializeField] string MainMenu;
    [SerializeField] string Dungeon;
    [SerializeField] string Overworld;
    [SerializeField] string Overworld_1;
    [SerializeField] string Guild;
    

    void Start()   {
        
    }

    

    public void GoToMainMenu() { LeaveHere(MainMenu); }         //sends us to main menu  
    public void GoToGuild() { LeaveHere(Guild); }               //Go To The Guild   
    public void GoToDungeon() { LeaveHere(Dungeon); }           //Go To The Dungeon 
    public void GoToOverworld() { LeaveHere(Overworld); }       //Go To The Overworld from dungeon
    public void GoToOverworld1() { LeaveHere(Overworld_1); }    //Go To The Overworld from adventurers guild

    // quits application
    public void ExitGame() {
        //screenTransition.Transition_Leaving();          //Start Screen Transition for leaving scenes
        StartCoroutine(DelayLeaveLevel());              //start Coroutine
        IEnumerator DelayLeaveLevel() {
            //yield return new WaitUntil(()=>screenTransition.GetDoneWithTransition());   //wait for transition to happen
            yield return null; 
            Application.Quit();                                          //load scene to consume once more
            yield return null; 
        }  
    }
    
    //Leave current area with screen transition
    public void LeaveHere(string whereToGo)  {
//        screenTransition.Transition_Leaving();            //Start Screen Transition for leaving scenes
        StartCoroutine(DelayLeaveLevel(whereToGo));         //start Coroutine
        IEnumerator DelayLeaveLevel(string whereToGo) {
           // yield return new WaitUntil(()=>screenTransition.GetDoneWithTransition());   //wait for transition to happen
            yield return null; 
            SceneManager.LoadScene(whereToGo);                                          //load scene to consume once more
            yield return null; 
        }  
    }
}
