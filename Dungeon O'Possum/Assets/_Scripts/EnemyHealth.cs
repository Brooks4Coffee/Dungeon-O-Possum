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
   
    [Header("Animations:")]
    [SerializeField] Animator anim; 
   
    [Header("Particle Systems:")]
    [SerializeField] ParticleSystem PS_takeDamage;
    [SerializeField] ParticleSystem PS_healing;
    //instances of particle systems:
    private ParticleSystem PS_takeDamageInstance; 
    private ParticleSystem PS_healingInstance;

    [SerializeField] SpawnCoins coinSpawner; 


    void Awake() {
        currentHealth = maxHealth;
        isDead = false; 
    }


    // Setter: Health  
    public void SetCurrentHealth(float health) {  currentHealth = health;  }
    //Getter: Health
    public float GetCurrentHealth() {  return currentHealth;  }
    // Setter: Max Health   
    public void SetMaxHealth(float newMaxHealth) {  maxHealth = newMaxHealth;  }
    //Getter: Health
    public float GetMaxHealth() {  return maxHealth;  }


    /*
     * 
     */ 
    public void TakeDamage(float damage, Vector2 attackDirection) {
        currentHealth -= damage;
        SpawnDamageParticles(attackDirection);      //spawn dmg particles
        //display this on UI/HUD healthbar
        if (currentHealth <= 0) {   //check if this damage dealth has killed this game object
            isDead = true; 
            coinSpawner.SpawnLoot(this.transform, attackDirection);
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
     * On Death: destroy game object
     */   
    private void death() {
        //anim.SetTrigger("Death");
        //*** TO DO: way to wait for animation to do its thing before destroying object
        Destroy(this.gameObject); 
    }
   
 
    /*
     * 
     */ 
    private void SpawnDamageParticles(Vector2 attackDirection) {
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, attackDirection);
        PS_takeDamageInstance = Instantiate(PS_takeDamage, transform.position, spawnRotation); 
        Destroy(PS_takeDamageInstance, 0.5f); 
    }
}