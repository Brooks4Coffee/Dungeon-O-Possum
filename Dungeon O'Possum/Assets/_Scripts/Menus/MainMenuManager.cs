using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [Header("Scene Transition:")]
    [SerializeField] Animator fadeTransition;

    public void StartGame() {
        //SceneManager.LoadScene("1_Tutorial");
        StartCoroutine(LoadAdventure());
        IEnumerator LoadAdventure() {
            fadeTransition.SetTrigger("End"); 
            yield return new WaitForSeconds(1.5f); 
            SceneManager.LoadScene("1_Tutorial");
        }
    }


    public void ExitGame() {
        //Application.Quit();
        StartCoroutine(LoadExit());
        IEnumerator LoadExit() {
            fadeTransition.SetTrigger("End"); 
            yield return new WaitForSeconds(1.5f); 
            Application.Quit();
        }
    }
}

