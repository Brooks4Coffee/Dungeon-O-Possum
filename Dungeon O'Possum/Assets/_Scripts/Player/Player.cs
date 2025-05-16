using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorials: https://www.youtube.com/watch?v=otqnmwfTg3I
//
public class Player : MonoBehaviour {

    // private static Player instance;


    [Header("Game Manager:")]
    [SerializeField] GameManager gm; //store world position here 

    [Header("PlayerControl:")]
    [SerializeField] PlayerControl pc; 
    Rigidbody2D rb;
    
    [Header("Health:")]
    [SerializeField] public Health health; 
    [SerializeField] bool canTakeDamage; 

    [Header("Speed:")]
    [SerializeField] float walkSpeed = 8.0f;
    [SerializeField] float currentSpeed;
    [SerializeField] float SprintSpeed = 11.0f;
    [SerializeField] public bool canSprint = true; 
    [SerializeField] public bool areSprinting = false; 

    [Header("Audio:")]
    [SerializeField] AudioClip audioClip_Sword; 
    [SerializeField] AudioSource audioSource_Sword;
    [Range(0, 1)]
    [SerializeField] float pitchRange = 0.2f;

    [Header("Stats:")]  
    [SerializeField] public int level;
    [SerializeField] public int XP;

    [Header("Particle Systems:")]
    [SerializeField] ParticleSystem PS_dustTrail;
    private ParticleSystem PS_dustTrailInstance;

    //[Header("Weapon:")]
    //[SerializeField] CurrentWeapon currentweapon;

    //Trackers: 



    void Awake()   {
        // if (instance == null)   {
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else   {
        //     Destroy(gameObject); // Prevent duplicates
        // }
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = walkSpeed;
        canTakeDamage = true;
        
    }
    

    // Moves player position by passing it a Vector3 containing + or - values on the respective axis that will calculate the direction we wish to head 
    public void Move(Vector3 movement, bool pcSaysSprint) {
        if (TestIfSprinting(pcSaysSprint)) {  //if sprinting, go fast! 
            currentSpeed = SprintSpeed; 
            if (!areSprinting) {
                areSprinting = true;
                SpawnDustParticles(movement);
            }
        } 
        else { 
            areSprinting = false;
            currentSpeed = walkSpeed; 
        }                                  //if walking, don't go fast! 
        rb.velocity = movement * currentSpeed;
    }


    //GETTERS: 
    public Health GetHealth(){ return health; }                 //health
    public int GetLevel(){ return level; }                      //rank/level 
    public int GetXP(){  return XP;  }                          //experience points
    public bool GetDamageableStatus() { return canTakeDamage; } //damageable status

    //SETTERS: 
    public void SetWalkSpeed(float speedupPercentage){ walkSpeed *= speedupPercentage;  }           //speed boost (blessings/levelingup)
    public void SetSprintSpeed(float speedupPercentage) {  SprintSpeed *= speedupPercentage;  }     //speed boost 
    public void SetDamageableStatus(bool isDamageable) { canTakeDamage = isDamageable; }            //set damageable bool



    //Check to see if we can sprint or if we want to sprint
    bool TestIfSprinting(bool pcSaysSprint){
        if (!canSprint) { return false; }   //if we can't sprint rn, return false
        if (pcSaysSprint) { return true;  } //if right mouse or left shift was hit, return true
        return false;                       //otherwise, return false
    }


    //Spawn dust particles when sprinting
    private void SpawnDustParticles(Vector2 sprintDirection) {
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, sprintDirection);
        PS_dustTrailInstance = Instantiate(PS_dustTrail, transform.position, spawnRotation); 
        Destroy(PS_dustTrailInstance.gameObject, 1f); 
    }

}

