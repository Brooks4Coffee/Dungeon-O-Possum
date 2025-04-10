using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [Header("Scene Transition:")]
    [SerializeField] Animator fadeTransition;

    public void StartGame() {
        SceneManager.LoadScene("1_Tutorial");
       // StartCoroutine(LoadOptions());
        // IEnumerator LoadOptions() {
        //     fadeTransition.SetTrigger("End"); 
        //     yield return new WaitForSeconds(1.5f); 
        //     SceneManager.LoadScene("1_Tutorial");
        // }
    }


    public void ExitGame() {
        Application.Quit();
        // StartCoroutine(LoadOptions());
        // IEnumerator LoadOptions() {
        //     fadeTransition.SetTrigger("End"); 
        //     yield return new WaitForSeconds(1.5f); 
        //     Application.Quit();
        // }
    }
}

