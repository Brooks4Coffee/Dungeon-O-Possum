using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntryTitle : MonoBehaviour    { 
    [Header("Title UI:")]
    [SerializeField] Image bg;                      //image that displays text and has dark bg
    [SerializeField] TextMeshProUGUI textUI;        //TMPro asset


    [Header("Title Settings:")]
    [SerializeField] string sceneTitle;             //text to display
    [SerializeField] Color colorBG;                 //if we want to change bg color to be something else
    [SerializeField] Color colorTXT;                //if we want to change bg color to be something else
    [SerializeField] float transitionTime = 1;      //how long fading lasts
    [SerializeField] float waitFinishTime = 1;      //how long we wait until calling disappear()
    [SerializeField] float waitTime = 1;            //how long we wait until calling disappear()
    [SerializeField] bool transitioning = true;    //are we currently transititoning?


    void Start()   {
        textUI.SetText(sceneTitle);
        StartCoroutine(waitasec());                   //call wait:
        IEnumerator waitasec()   {
            yield return new WaitForSeconds(waitTime);     // Wait a sec
            yield return null;                             //just in case
        }
        TitleDisplay();                     //1. fade in
    }

    void Update()  {   
        StartCoroutine(waitasec());                   //call wait:
        IEnumerator waitasec()   {
            new WaitForSeconds(waitTime);     // Wait a sec
            TitleDisappear(); 
            gameObject.SetActive(false);
            yield return null;                             //just in case
        }
    }


    //Display Title
    public void TitleDisplay()  {
        Debug.Log("fading in now");
        StartCoroutine(FadeDisplay());
        IEnumerator FadeDisplay() {
            float time = 0; 
            while ((time < transitionTime) && (textUI.color.a > colorTXT.a) && (bg.color.a > colorBG.a)) {
                yield return null; 
                time += Time.deltaTime;
                bg.color = new Color(colorBG.r, colorBG.g, colorBG.b, time/transitionTime);
                textUI.color = new Color(colorTXT.r, colorTXT.g, colorTXT.b, time/transitionTime);
            }
            bg.color = colorBG;             //Ensure Color is set
            textUI.color = colorTXT;        //Ensure Color is set
            transitioning = false;          //done with transition
            yield return null; 
        }
        //transitioning = false;          //done with transition
    }

    //Make Title Disappear
    public void TitleDisappear()  {
        if (transitioning) { return; }  //if in the middle of a transition already, return
        transitioning = true;                   //set alert that we're transitioning to true
        Debug.Log("fading out now");
        StartCoroutine(FadeDisappear());
        IEnumerator FadeDisappear() {
            float time = 0; 
            while (time < transitionTime) {
                yield return null; 
                time += Time.deltaTime;
                bg.color = new Color(colorBG.r, colorBG.g, colorBG.b, 1f-(time/transitionTime));
                textUI.color = new Color(colorTXT.r, colorTXT.g, colorTXT.b, 1f-(time/transitionTime));
            }
            bg.color = Color.clear;             //clear any remaining color in bg
            textUI.color = Color.clear;         //clear any remaining color in txt
            transitioning = false;              //done with transition
            yield return null; 
        }        
    }

    
}
