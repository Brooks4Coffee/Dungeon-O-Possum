using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

//Tutorials Used: https://www.youtube.com/watch?v=0HKSvT2gcuk for particles
public class EnemyHealth : MonoBehaviour, IDamageable  {    
   
    [Header("Health:")]
    [SerializeField] float maxHealth = 100.0f;
    [SerializeField] float currentHealth;
    [SerializeField] bool isDead; 
    public bool HasTakenDamage { get; set; }
   
    [Header("Animations:")]
    [SerializeField] Animator anim; 

   [Header("is Enemy?:")]
    [SerializeField] bool isEnemy; 

    [Header("Particle Systems:")]
    [SerializeField] ParticleSystem PS_takeDamage;
    //instances of particle systems:
    private ParticleSystem PS_takeDamageInstance; 

    [SerializeField] SpawnCoins coinSpawner; 


    void Awake() {
        currentHealth = maxHealth;
        isDead = false; 
    }


    // Setters: 
    public void SetCurrentHealth(float health) {  currentHealth = health;  }        //current health
    public void SetMaxHealth(float newMaxHealth) {  maxHealth = newMaxHealth;  }    //max health
    
    //Getters:
    public float GetCurrentHealth() {  return currentHealth;  } //current health
    public float GetMaxHealth() {  return maxHealth;  }         //max health


    //Take damage via weapon/magic
    public void TakeDamage(float damage, Vector2 attackDirection) {
        currentHealth -= damage;
        SpawnDamageParticles(attackDirection);      //spawn dmg particles
        if (currentHealth <= 0) {       //check if this damage dealth has killed this game object
            isDead = true; 
            if (isEnemy) {  coinSpawner.SpawnLoot(this.transform, attackDirection); }
            death();
            return; 
        }
        //anim.SetTrigger("Hurt");  //play particle/animation of getting hurt
    }


    //Use magic or healing item to heal. 
    //*** TO DO: make one that heals you over time.
    public void UseHealingItem(float healing){
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
    
 
    //On Death: destroy game object
    private void death() {
        //anim.SetTrigger("Death");
        //*** TO DO: way to wait for animation to do its thing before destroying object
        Destroy(this.gameObject); 
    }
   
 
    //Spawn damage particles when hit
    private void SpawnDamageParticles(Vector2 attackDirection) {
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, attackDirection);
        PS_takeDamageInstance = Instantiate(PS_takeDamage, transform.position, spawnRotation); 
        Destroy(PS_takeDamageInstance, 1); 
    }
}