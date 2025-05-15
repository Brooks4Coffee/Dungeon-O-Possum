using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition_Fading : MonoBehaviour {


    [SerializeField] Image transitionImage;
    [SerializeField] Color transitionColor = Color.black;
    [SerializeField] float transitionTime = 1;
    [SerializeField] bool transitionOnStart = false;
    bool transitioning = false;
    bool doneWithTransition = false;


    void Start() { if (transitionOnStart){ Transition_Entering(); } } //if entering scene, call corrosponding method


    //Transition for Entering a Scene
    public void Transition_Entering()  {
        if (transitioning) { return; }          //if in the middle of a transition already, return
        transitioning = true;                   //set alert that we're transitioning to true
        StartCoroutine(TransitionEnter());
        IEnumerator TransitionEnter() {
            float time = 0; 
            while (time < transitionTime) {
                yield return null; 
                time += Time.deltaTime;
                transitionImage.color = new Color(transitionColor.r, transitionColor.g, transitionColor.b, 1f-(time/transitionTime));
            }
            transitionImage.color = Color.clear;    //clear any remaining color 
            transitioning = false;                  //done with transition
            gameObject.SetActive(false);
            yield return null; 
        }        
    }


    //Transition for Leaving a Scene
    public void Transition_Leaving()  {
        if (transitioning) { return; }  //if in the middle of a transition already, return
        gameObject.SetActive(true);
        transitioning = true;           //set alert that we're transitioning to true
        StartCoroutine(TransitionLeave());
        IEnumerator TransitionLeave() {
            float time = 0; 
            while (time < transitionTime) {
                yield return null; 
                time += Time.deltaTime;
                transitionImage.color = new Color(transitionColor.r, transitionColor.g, transitionColor.b, time/transitionTime);
            }
            transitionImage.color = transitionColor;
            transitioning = false;  //done with transition
            doneWithTransition = true; 
            yield return null; 
        }
    }

    //Getter for Whether the Transition_Leaving() method is complete
    public bool GetDoneWithTransition(){ return doneWithTransition; }
}

