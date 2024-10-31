using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [Header("Scene Transition:")]
    [SerializeField] Animator fadeTransition;

    public void StartGame() {
        StartCoroutine(LoadOptions());
        IEnumerator LoadOptions() {
            fadeTransition.SetTrigger("End"); 
            yield return new WaitForSeconds(1.5f); 
            SceneManager.LoadScene("1_Tutorial");
        }
    }

    public void GoToOptions() {
        StartCoroutine(LoadOptions());
        IEnumerator LoadOptions() {
            fadeTransition.SetTrigger("End"); 
            yield return new WaitForSeconds(1.5f); 
            SceneManager.LoadScene("AdventerersGuild");
        }
    }

    public void ExitGame() {
        StartCoroutine(LoadOptions());
        IEnumerator LoadOptions() {
            fadeTransition.SetTrigger("End"); 
            yield return new WaitForSeconds(1.5f); 
            Application.Quit();
        }
    }
}

