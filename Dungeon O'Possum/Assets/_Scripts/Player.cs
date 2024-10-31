using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Player RigidBody2D:
    Rigidbody2D rb;
    [Header("PlayerControl:")]
    [SerializeField] PlayerControl pc; 
    
    [Header("Health:")]
    [SerializeField] public Health health; 

    [Header("Speed:")]
    [SerializeField] float speed = 8.0f;

    [Header("Audio:")]
    [SerializeField] AudioClip audioClip; 
    [SerializeField] AudioSource audioSource;
    [Range(0, 1)]
    [SerializeField] float pitchRange = 0.2f;

    [Header("Stats:")]  
    [SerializeField] public int level;
    [SerializeField] public int XP;

    //[Header("Weapon:")]
    //[SerializeField] CurrentWeapon currentweapon;

    //Trackers: 


    /*
     * Fetches Rigidbody2D before game 'starts' 
     */
    void Awake() { 
        //healthbar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();

    }
    

    void FixedUpdate(){
        
    }


    /*
     * Getter for Current Weapon object 
     */
    // public CurrentWeapon Getblaster(){
    //     return blaster;
    // }

    /*
     * Moves player position by passing it a Vector3 containing + or - values on the respective axis that will calculate the direction we wish to head 
     */
    public void Move(Vector3 movement) {
        transform.localPosition += movement * speed * Time.deltaTime;
        //rb.AddForce(movement * speed);
    }


    /*
     * calls for firing blaser 
     */
    public void ShootBlaster(){
        //blaster.FireBlaster();
    }


    //GETTERS: 
    public Health GetHealth(){ return health; } //health
    public int GetLevel(){ return level; }      //rank/level 
    public int GetXP(){  return XP;  }          //experience points

    //SETTERS: 
    public void SetSpeed(float speedupPercentage){ speed = speed * speedupPercentage;  }    //speed boost (blessings/levelingup)
   // public void SetSpeed(float speedupPercentage)
}

