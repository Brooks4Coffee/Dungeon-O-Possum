using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition_Fading : MonoBehaviour {
    [Header("Image and Colors")]
    [SerializeField] Image self; 
    [SerializeField] Image Sword;
    [SerializeField] Color startColor;
    [SerializeField] Color fadeColor = Color.black;



    [Header("Supporting Fields")]
    [SerializeField] float fadeTime = 1; 
    [SerializeField] float fadeSpeed = 0.01f; 
    [SerializeField] bool fadeWhenOnStart = true; 
    bool fadingNow = false; 
    bool fallingDone = false; 


     void Start(){
        if(fadeWhenOnStart){
            FadeTransition_IntoScene();
        }
    }


    public void FadeTransition_IntoScene () {    //screen falls from top to cover scene
        if (fadingNow) { return; }
        fadingNow = true;

        StartCoroutine(FadingIntoSceneRoutine()); 
        IEnumerator FadingIntoSceneRoutine() {
            float t = 0; 
            while(t < fadeTime) {
                yield return null; 
                t += Time.deltaTime; 
                self.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f-(t/fadeTime));
                //Sword.color = new Color(Sword.color.r, Sword.color.g, Sword.color.b, 1f-(t/fadeTime));
                //transform.Translate(0, -fallSpeed, 0);
            }
            self.color = Color.clear;
            fadingNow = false; 
            yield return null;             
        }
        //self.GetComponent<GameObject>().SetActive(false);
        //Sword.GetComponent<GameObject>().SetActive(false);
    }

    public bool GetFallingDone(){  return fallingDone;  }



    //Fade out of scene into given color. 
    public void FadeTransition_OutOfScene() {    //screen fades
        //self.GetComponent<GameObject>().SetActive(true);
        //Sword.GetComponent<GameObject>().SetActive(true);
        if (fadingNow) { return; }
        fadingNow = true;

        StartCoroutine(FadingOutOfSceneRoutine()); 
        IEnumerator FadingOutOfSceneRoutine() {
            float t = 0; 
            while(t < fadeTime) {
                yield return null; 
                t += Time.deltaTime; 
                self.color = new Color(self.color.r, self.color.g, self.color.b, t/fadeTime);
                //Sword.color = new Color(Sword.color.r, Sword.color.g, Sword.color.b, t/fadeTime);
                //transform.Translate(0, fadeSpeed, 0);
            }
            self.color = fadeColor;
            fadingNow = false;  //we're now done fading so this action is completed
            fallingDone = true;
            yield return null; 

        }        
    }
}
