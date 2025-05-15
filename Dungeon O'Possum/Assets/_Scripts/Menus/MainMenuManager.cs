using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [Header("Scene Transition:")]
    [SerializeField] ScreenTransition_Fading fader;
    [SerializeField] string startScene; 

    public void StartGame() {
        fader.Transition_Leaving(); 
        StartCoroutine(LoadAdventure());
        IEnumerator LoadAdventure() {
            yield return new WaitUntil(()=>fader.GetDoneWithTransition());
            SceneManager.LoadScene(startScene);
        }
    }


    public void ExitGame() {
        fader.Transition_Leaving(); 
        StartCoroutine(LoadExit());
        IEnumerator LoadExit() {
            yield return new WaitUntil(()=>fader.GetDoneWithTransition());
            Application.Quit();
        }
    }
}

