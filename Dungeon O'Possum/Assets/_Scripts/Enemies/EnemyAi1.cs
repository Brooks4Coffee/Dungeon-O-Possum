using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType {
    MAGE,       //attacks via staying a distance away from player and shooting projectiles at the player
    FIGHTER,    //attacks via persuing the player and hitting it with weapon
    SPECIAL     //can attack either way
}

//wanted to try this out
// public enum AIState { 
//     IDLE,       //stays in one spot minding its own business
//     PATROL,     //moves around a given area
//     ATTACK      //uses its class type means to attack player
// }




public class EnemyAi1 : MonoBehaviour  {
    
    [Header("State and Beings:")]
    [SerializeField] string currentStateString;
    [SerializeField] Transform viewPoint;
    [SerializeField] Enemy self;
    [SerializeField] ProjectileLauncher projLauncher;
    [SerializeField] EnemyHealth health;
    [SerializeField] Player target;
    [SerializeField] EnemyType enemyType;

    [Header("Config")]
    [SerializeField] float sightDistance = 10;
    [SerializeField] float Time_IdleDuration = 1.25f; 
    [SerializeField] float Time_PatrolDuration = 2.25f; 
    [SerializeField] float patrolArea = 10f; 
    [SerializeField] float attackRange = 8.0f;


    [Header("Proc Gen")]
    [SerializeField] int Seed;
    [SerializeField] float minIdleTime = 1.25f; 
    [SerializeField] float maxIdleTime = 2.25f; 
    [SerializeField] float minPatrolTime = 0.95f; 
    [SerializeField] float maxPatrolTime = 1.45f; 


    [Header("Layers")]
    public LayerMask obstacleMask;  //layer mask for other
    public LayerMask wallLayer;     // Layer mask for walls


    //trackers==================================================
    delegate void AIState();    //stores method that takes no info and returns no info. 
    private AIState currentState;
    
    float stateTimer = 0;
    bool justChangedState = false;
    Vector3 lastTargetPos;                      //Where player was seen last
    Vector3 patrolPos;
    Vector3 patrolPivot; 
    private Vector2 moveDirection;


    void Start()  {
        ChangeState(IdleState);                                 //on start: Enemy will be idle
        Generate(Random.Range(int.MinValue, int.MaxValue));     //Generate Random State Timer Values 
        patrolPivot = self.transform.position;                  //Enemys will now move in their own individual areas rather than flock to one spot
    }

    void Generate(int givenSeed) {
        this.Seed = givenSeed;
        Random.InitState(givenSeed);
        Time_IdleDuration = Random.Range(minIdleTime, maxIdleTime);         //random idle duration
        Time_PatrolDuration = Random.Range(minPatrolTime, maxPatrolTime);   //random patrol duration
    }

    void FixedUpdate()  {
        AITick();
    }

    //=============================================================================================================================== STATE MACHINE 
    /*
     * Finite State Machine that run this state every frame until its changed to another (which repeats the process)
     *      - This will hopefully stop two states running at the same time
     *      - 
     */
    void AITick(){
        if (justChangedState) {
            stateTimer = 0;
            justChangedState = false;
        }
        currentState();
        stateTimer += Time.deltaTime;
    }


    //=========================================================
    // STATE: Idle 
    //      - literally just kinda stands there 
    void IdleState(){
        //on entering this state, update state information
        if (stateTimer == 0) {  currentStateString = "IdleState";  }            

        if (stateTimer >= Time_IdleDuration) {    //Go To Patrol State
            ChangeState(PatrolState);
            return;
        }

        if (LookForTarget())  {                  //Go To Attack State 
            ChangeState(AttackState);  
            return;
        }
    }



    //=========================================================
    // STATE: Patrol - walks around given area  
    void PatrolState(){
        if (stateTimer == 0) {   //on entering this state, update state information
            currentStateString = "PatrolState";
            patrolPos = patrolPivot + new Vector3(Random.Range(-patrolArea, patrolArea), Random.Range(-patrolArea, patrolArea));
            moveDirection = (patrolPos - transform.position).normalized;
        }
        // while (PathFind(patrolPos - transform.position) == false) {
        //     patrolPos = self.transform.position + new Vector3(Random.Range(-patrolArea, patrolArea), Random.Range(-patrolArea, patrolArea));
        // }
        if (PathFind(patrolPos - transform.position) ){
            self.Move((Vector3)moveDirection);
        }       

        if (stateTimer >= Time_PatrolDuration) { ChangeState(IdleState);  }
    }


    //=========================================================
    // STATE:  Attack
    //      - upon spotting player, it will attack player 
    //
    void AttackState(){
        if (stateTimer == 0) {   //on entering this state, update state information
            currentStateString = "AttackState";
        }
        switch(enemyType) {     //depending on its class, choose how it attacks
            case EnemyType.MAGE:
                //Launch Projectiles and keep distance from player
                break;
            case EnemyType.FIGHTER:
                //Move towards player and attack
                break;
            case EnemyType.SPECIAL:
                //Special attack
                break; 
        }

        //if player is out of given attack/sight distance, change to patrol state
        if (Vector3.Distance(transform.position, target.transform.position) > sightDistance){    
            ChangeState(PatrolState);
        }
        self.MoveToward(target.GetComponent<Transform>().position);        
    }

    //=====================================================OTHER HELPER FUNCTIONS
    //Setter for Current State
    void ChangeState(AIState newAIState){
        currentState = newAIState;
        justChangedState = true;
    }


    //checks for player in field of vision 
    bool LookForTarget(){
        //unsurprisingly: if we're dead or out of site, it's gonna be hard to spot us
        if (target == null) {  return false;  }  
        

        // Check if distance is too far:
        if (Vector3.Distance(transform.position, target.transform.position) > sightDistance) {
            return false;
        }

        // Check for line of sight if player is within sight distance:
        //grab player's direction for Raycast
        Vector3 directionToPlayer = (target.transform.position - transform.position).normalized;
        //use Raycast to see if anything is blocking our vision/path to player
        if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, sightDistance, obstacleMask)) {
            return hit.collider.CompareTag("Player");   //returns bool if we can see player via ray casting
        }

        return false;  
    }


    private bool PathFind (Vector3 direction) {
        if (Physics.Raycast(transform.position, direction, 1f, wallLayer))  {
            return false; // Wall was detected
        }
        return true; //wall was not detected in path
    }

    void OnTriggerEnter2D (Collider2D other)  {
        if (other.CompareTag("Walls")) {
            Debug.Log("Enemy Has hit a wall, yikes"); 
            moveDirection = -moveDirection;
        }
    }
    /*
     * Shows us our sight range while we work in editor
     */
    void OnDrawGizmosSelected() {
        if (viewPoint == null) {
            return; 
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(viewPoint.position, sightDistance);
    }

    //Getters
    public float GetIdleTime() { return Time_IdleDuration; }
    public float GetPatrolTime() { return Time_PatrolDuration; }

}
