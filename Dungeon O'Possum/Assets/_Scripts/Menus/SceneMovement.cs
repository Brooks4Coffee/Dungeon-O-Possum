using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour  {
    
    [Header("Player:")]
    [SerializeField] Player player;
    [SerializeField] PlayerState pt;

    [Header("Screen Transition:")]   
    [SerializeField] ScreenTransition_Fading screenTransition;

    [Header("Scene Names:")]
    [SerializeField] string MainMenu;
    [SerializeField] string Dungeon;
    [SerializeField] string Overworld;
    [SerializeField] string Guild;
    

    void StorePlayerPosition() { pt.storeWorldPos(player.transform.position); }
    

    public void GoToMainMenu() { LeaveHere(MainMenu); }         //sends us to main menu  
    public void GoToGuild() {                                   //Go To The Guild   
        StorePlayerPosition();
        LeaveHere(Guild); 
    }
    public void GoToDungeon() {                                 //Go To The Dungeon 
        StorePlayerPosition();
        LeaveHere(Dungeon); 
    }
    public void GoToOverworld() { LeaveHere(Overworld); }       //Go To The Overworld from dungeon

    // quits application
    public void ExitGame() {
        screenTransition.Transition_Leaving();          //Start Screen Transition for leaving scenes
        StartCoroutine(DelayLeaveLevel());              //start Coroutine
        IEnumerator DelayLeaveLevel() {
            yield return new WaitUntil(()=>screenTransition.GetDoneWithTransition());   //wait for transition to happen
            Application.Quit();                                          //load scene to consume once more
            yield return null; 
        }  
    }
    
    //Leave current area with screen transition
    public void LeaveHere(string whereToGo)  {
        screenTransition.Transition_Leaving();              //Start Screen Transition for leaving scenes
        StartCoroutine(DelayLeaveLevel(whereToGo));         //start Coroutine
        IEnumerator DelayLeaveLevel(string whereToGo) {
            screenTransition.gameObject.SetActive(true);
            yield return new WaitUntil(()=>screenTransition.GetDoneWithTransition());   //wait for transition to happen
            SceneManager.LoadScene(whereToGo);                                          //load scene to consume once more
            yield return null; 
        }  
    }
}
