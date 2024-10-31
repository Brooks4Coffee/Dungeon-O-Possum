using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Health : MonoBehaviour  {    
   
    [Header("Health:")]
    [SerializeField] float maxHealth = 30.0f;
    [SerializeField] float currentHealth;
    [SerializeField] bool isDead; 
   
    [Header("Animations:")]
    [SerializeField] Animator anim; 
   
    [Header("Particle Systems:")]
    [SerializeField] ParticleSystem PS_takeDamage;
    [SerializeField] ParticleSystem PS_healing;
    [SerializeField] ParticleSystem PS_sprint;


    /*
     * 
     */  
    void Awake() {
        currentHealth = maxHealth;
        isDead = false; 
    }


    // void Update() {
    //     if (Input.GetKeyDown(KeyCode.T)) {
    //         TakeDamage(25);
    //     }
    // }


    //SETTERS: 
    public void SetCurrentHealth(float health) { currentHealth = health; }          //current health
    public void SetMaxHealth(float newMaxHealth) { maxHealth = newMaxHealth; }      //max health

    //GETTERS: 
    public float GetCurrentHealth() { return currentHealth; }       //current health
    public float GetMaxHealth() { return maxHealth; }               //max health


    //input is how many hearts to add. 
    public void BlessCurrentHealth(int addHeart) {
        maxHealth += addHeart * 10;
        currentHealth = maxHealth; //also heals player
    }


    /*
     * 
     */ 
    public void TakeDamage(float damage) {
        currentHealth -= damage;
        //display this on UI/HUD healthbar
        if (currentHealth <= 0) {   //check if this damage dealth has killed this game object
            isDead = true; 
            death();
            return; 
        }
        //anim.SetTrigger("Hurt");  //play particle/animation of getting hurt
    }


    /*
     * 
     */ 
    public void UseHealingItem(float healing){
        //*** TO DO: make one that heals you over time.
        float temp = currentHealth; 
        temp += healing; 
        if (temp <= 100) {
            SetCurrentHealth(temp);
        }
        else {
            SetCurrentHealth(maxHealth); 
        }
        //anim.SetTrigger("Heal");
    }


    /*
     * When entering collision 
     */
    void OnTriggerEnter2D(Collider2D other){
    //     if (other.CompareTag("DamageObject")){
    //         Debug.Log("-25 Health!");
    //         health.TakeDamage(0.25f);
    //         audioSource.pitch = Random.Range(1f - pitchRange, 1f + pitchRange);     //randomizes the pickup sound pitch every time take damage
    //         audioSource.PlayOneShot(audioClip);                                     //different from audiosource.Play(); it layers sound effect, so no cutting it off                                             
    //     }
    }
    
 
    /*
     * On Death: destroy game object
     */   
    private void death() {
        //anim.SetTrigger("Death");
        //*** TO DO: way to wait for animation to do its thing before destroying object
        Destroy( transform.root.gameObject ); //destroys player object
    }
}