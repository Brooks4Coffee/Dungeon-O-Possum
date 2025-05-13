using UnityEngine;
using UnityEngine.UI;



public class UICloudMover  : MonoBehaviour  {
    
    [Header("Basic Variables:")]
    [SerializeField]  float speed = 50.0f;        // the current speed of clouds (per sec)
    [SerializeField]  float Ypos = 0.0f;        // the current Y position for reset
    [SerializeField]  float scale = 1.0f;       // the current cloud size

    [Header("Randomizer Variables:")]
    [SerializeField]  float minSpd = 50f;       // the min speed of clouds (per sec)
    [SerializeField]  float maxSpd = 100f;      // the max speed of clouds (per sec)
    [SerializeField]  float minY = -200f;       // the min Y position for reset
    [SerializeField]  float maxY = 200f;        // the max Y position for reset
    [SerializeField]  float minScale = 0.5f;    // the min cloud size
    [SerializeField]  float maxScale = 1.5f;    // the max cloud size

    private RectTransform rt;
    [SerializeField]  private float screenWidth;



    void Start()    {
        rt = GetComponent<RectTransform>();     //grab current obj's r-transform
        screenWidth = Screen.width;             //grab screen width
    }


    //will call necessary functions
    void Update()   {
        moveCloud();
        if (rt.anchoredPosition.x > screenWidth - 2100) {  ResetCloud(); }
    }


    //Moves Cloud
    void moveCloud() { rt.anchoredPosition += Vector2.right * speed * Time.deltaTime; }


    //Resets and randomizes the cloud. 
    void ResetCloud()    {
        //Change Position
        float startX = -rt.rect.width - 1000f;               // Set X to just off-screen left
        Ypos = Random.Range(minY, maxY);                    // Set Y to Random Position between our variables
        rt.anchoredPosition = new Vector2(startX, Ypos);    // -> Move Cloud to this position!
          
        //Change Speed
        speed = Random.Range(minSpd, maxSpd);

        //Change Scale
        scale = Random.Range(minScale, maxScale);           // Random scale (uniform)
        rt.localScale = new Vector3(scale, scale, 1f);      // -> Change Cloud Scale!
    }
}
