using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishingMiniGame : MonoBehaviour  {

    [Header("Player:")]
    [SerializeField] PlayerControl PC; 
    [SerializeField] Inventory playerInventory; //to add to count

    [Header("Fish Movement Config:")]
    [SerializeField] float moveSpeed = 224.8f;
    [SerializeField] float movedecaySpeed = 136.1f;

    [Header("Catch/Decay on Progress:")]
    [SerializeField] float catchSpeed = 0.08f;
    [SerializeField] float decaySpeed = 0.05f;

    [Header("Anchor Points:")]
    [SerializeField] float maxY = 146f;
    [SerializeField] float minY = -104.4f;

    [Header("UI/Game Elements:")]
    [SerializeField] RectTransform fish;
    [SerializeField] RectTransform sweetspot;
    [SerializeField] Slider progressBar;

    [Header("EndGame MSG:")]
    [SerializeField] GameObject EndGamePanel; 
    [SerializeField] NoticeMsg msg;         
    [SerializeField] string winTxt;         
    [SerializeField] string loseTxt;       
    [SerializeField] bool givenFish = false;                  
      
    [Header("Audio:")]
    [SerializeField] AudioSource audioSource;   //fishing sound
    [Range(0,1)]
    [SerializeField] float pitchRange = 0.2f;

    //trackers
    Vector2 initialFishPosition;


    void Awake()  {
        initialFishPosition = fish.anchoredPosition;
        EndGamePanel.SetActive(false); 
        progressBar.value = 40;  //make sure no saved progress from previous catches
    }

    void Update()  {
        PC.isInMinigame = true; 
        MoveFish();
        UpdateProgress();
    }


    //Check if fish and sweet spot are overlapping 
    bool IsOverlapping()  {  
        float fishTop = fish.anchoredPosition.y + fish.GetComponent<RectTransform>().rect.height / 2;
        float fishBottom = fish.anchoredPosition.y - fish.GetComponent<RectTransform>().rect.height / 2;
        float catchTop = sweetspot.anchoredPosition.y + sweetspot.GetComponent<RectTransform>().rect.height / 2;
        float catchBottom = sweetspot.anchoredPosition.y - sweetspot.GetComponent<RectTransform>().rect.height / 2;

        return !(fishBottom > catchTop || fishTop < catchBottom);
    }
    

    
    void MoveFish()  {
        if (Input.GetMouseButton(0)) {
            audioSource.pitch = Random.Range(1f-pitchRange, 1f+pitchRange);
            audioSource.Play();
            if (fish.anchoredPosition.y >= maxY) { return; }  
            // Move the fish using anchoredPosition for UI elements
            Vector2 newPosition = fish.anchoredPosition + new Vector2(0, 1 * moveSpeed * Time.deltaTime);
            
            // Clamp the Y position to keep it within minY and maxY
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            fish.anchoredPosition = newPosition;
        } 
        else {
            
            if (fish.anchoredPosition.y <= minY) { return; } 
            Vector2 newPosition = fish.anchoredPosition + new Vector2(0, -1 * movedecaySpeed * Time.deltaTime);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            fish.anchoredPosition = newPosition;
        }
    }


    void UpdateProgress()  {
        if (AreOverlapping()) {  progressBar.value += catchSpeed * 2;  }
        else  { progressBar.value -= decaySpeed * 2;  }

        if (progressBar.value >= progressBar.maxValue)  {
            if (!givenFish) {
                playerInventory.AddToFishCount();
                givenFish = true;
            }
            Pause();
            EndGamePanel.SetActive(true);
            msg.ShowText(winTxt);
        }

        else if (progressBar.value <= 0) {
            Pause();
            EndGamePanel.SetActive(true);
            msg.ShowText(loseTxt);
        }
    }


    //Pauses game
    public void Pause() { Time.timeScale = 0.0f;   }

    //Resumes game
    public void Resume() { Time.timeScale = 1.0f;   }

    //Resets game
    public void ResetMinigame() { 
        EndGamePanel.SetActive(false);
        progressBar.value = 28;  
        givenFish = false;
        fish.anchoredPosition = initialFishPosition;
    }


    //GOT HELP WITH THIS PART===============================================
    bool AreOverlapping() {
        Rect rectA = GetRected(sweetspot);
        Rect rectB = GetRected(fish);
        return rectA.Overlaps(rectB);        // Check if the two rectangles overlap
    }

    Rect GetRected(RectTransform rectTransform) {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        Vector2 size = new Vector2(
            rectTransform.rect.width * rectTransform.lossyScale.x,
            rectTransform.rect.height * rectTransform.lossyScale.y
        );
        return new Rect(corners[0], size);
    }

}
