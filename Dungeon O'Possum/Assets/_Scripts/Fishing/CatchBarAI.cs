using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBarAI : MonoBehaviour  {
    
    [Header("State and Beings:")]
    [SerializeField] string currentStateString;
    
    [Header("Catch Bar:")]
    [SerializeField] RectTransform sweetspot;
    [SerializeField] int direction = 1;         //1 = up, -1 = down


    [Header("Timers:")]
    [SerializeField] float idleDuratation;   //how long the bar stays in one place
    [SerializeField] float moveDuration;     //how long the bar moves in a given direction
    [SerializeField] float idleTimer;        //
    [SerializeField] float moveTimer;        //

    [Header("Proc Gen")]
    [SerializeField] int Seed;
    [SerializeField] float minIdleTime = 1.25f; 
    [SerializeField] float maxIdleTime = 2.25f; 
    [SerializeField] float minMoveTime = 0.15f; 
    [SerializeField] float maxMoveTime = 1.45f; 

    [Header("Movement Configurations:")]
    [SerializeField] float maxY = 0.05f;
    [SerializeField] float minY = 0.05f;
    [SerializeField] float speed = 1.0f;
    [SerializeField] Vector3 movement = Vector3.zero;

    //trackers==================================================
    delegate void AIState();    //stores method that takes no info and returns no info. 
    private AIState currentState;
    
    float stateTimer = 0;
    bool justChangedState = false;



    
    void Start()  {
        ChangeState(IdleState);                                 //on start: Enemy will be idle
        Generate(Random.Range(int.MinValue, int.MaxValue));     //Generate Random State Timer Values 
    }


    void FixedUpdate()  {   AITick();  }


    //Genrates Random timers for our states. mixes things up a bit
    void Generate(int givenSeed) {
        this.Seed = givenSeed;
        Random.InitState(givenSeed);
        idleDuratation = Random.Range(minIdleTime, maxIdleTime);         //random idle duration
        moveDuration = Random.Range(minMoveTime, maxMoveTime);          //random patrol duration
    }


    //AI Driver
    void AITick(){
        if (justChangedState) {
            stateTimer = 0;
            justChangedState = false;
        }
        currentState();
        stateTimer += Time.deltaTime;
    }    
    

    //Setter for Current State
    void ChangeState(AIState newAIState){
        currentState = newAIState;
        justChangedState = true;
    }


    //change direction our catch bar is heading
    void ChangeDirection() {
        if(sweetspot.localPosition.y <= minY) {direction = 1;}              //check if we're on lower edge
        else if (sweetspot.localPosition.y >= maxY) { direction = -1; }     //check if we're on upper edge
        else { 
            float randValue = Random.Range(-20, 20);
            if (randValue < 0) { direction = -1; }
            else { direction = 1; }
        }
    }


    void MoveCatchBar()  {
        if ((sweetspot.anchoredPosition.y >= maxY) && (direction != -1)) { 
            direction = -1; 
            return; 
        }  
        if ((sweetspot.anchoredPosition.y <= minY) && (direction != 1))  { 
            direction = 1;
            return; 
        }
        Vector2 newPosition = sweetspot.anchoredPosition + new Vector2(0, direction * speed * Time.deltaTime);
            
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY+1);
        sweetspot.anchoredPosition = newPosition;
        Generate(Random.Range(int.MinValue, int.MaxValue));     //Generate Random State Timer Values 
    }

    //==========================================================================================
    // STATE = Idle: - literally just kinda stands there 
    void IdleState(){
        //on entering this state, update state information
        if (stateTimer == 0) {  currentStateString = "IdleState";  }            

        if (stateTimer >= idleDuratation) {    //Go To Patrol State
            ChangeState(MoveState);
            return;
        }
    }



    // STATE: Patrol - walks around given area  
    void MoveState(){
        if (stateTimer == 0)  {   //on entering this state, update state information
            currentStateString = "PatrolState";
            ChangeDirection();
        }
        if (stateTimer >= moveDuration) { ChangeState(IdleState);  }
        MoveCatchBar(); 
    }
}
