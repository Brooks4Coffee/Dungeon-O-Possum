using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour  {

    [Header("Game Objects:")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Player player; 
    [SerializeField] EnemyAi1 self; 
    
    [Header("Spawn Position:")]
    [SerializeField] Transform spawnTransform;      //where we launch projectile from 

    [Header("Config:")]
    [SerializeField] float blastSpeed = 10.0f;
    [SerializeField] float cooldownTime = 0.5f;
    [SerializeField] float currentTime = 0.0F;
    [SerializeField] float rotateSpeed = 10.0f;
    [SerializeField] int lifeTime = 5; 

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [Range(0,1)]
    [SerializeField] float pitchRange = .2f;

    [Header("Ammo :")]
    [SerializeField] int maxAmmo = 5;                   //max amount that can be fired before reloading
    [SerializeField] int currentAmmo = 5;               //how much ammo we have (left) 
    [SerializeField] float maxReloadTime = 10;          //reload time once projectile Ammo runs out
    [SerializeField] float coolDownTime = .25f;         //cool down time until we can fire again
    [SerializeField] float projectileSpeed = 10.0f;     //speed of projectile once launched
    [SerializeField] int projectileCount = 1;           //how many to fire at a time
    [SerializeField] float currentReloadTime = 0;       //how long it takes to reload
    [SerializeField] float rotationSpeed = 10.0f; 

    //trackers
    EnemyAi1 ownerObject;
    bool coolingDown = false;




    // adds to cooldown timer for launcher
    void Update()  {
        if (currentTime < (cooldownTime + 20)) {    //we don't want number to get too big...
            currentTime += Time.deltaTime;          //add to time so we can use blaster again
        }
    }



    // Overloaded Aim Blaster 
    public void AimLauncher (Transform aimTransform) {
        AimLauncher(aimTransform.position);
    }


    // Function that does the aiming based on Vector3 
    public void AimLauncher(Vector3 aimDirection){ 
        Quaternion ToRotation = Quaternion.LookRotation(Vector3.forward, aimDirection - transform.position);
        Quaternion FromRotation = transform.rotation;
        transform.rotation = Quaternion.Lerp(FromRotation, ToRotation, Time.deltaTime * rotateSpeed);    
   } 


    /*
     * Calling it will check the current cooldown time vs how long we need to wait to cool down
     *      - if we are above: fire new blast in spawner's up position, play noise, destoy object after xyz amount of time
     *      - if we are not: return
     */
    public void LaunchProjectile() {
        if ((currentAmmo < 1) || (currentReloadTime > 0) || (coolingDown)) {        //Do Checks to see if we can fire: 
            return; 
        }
        CoolDown();
        currentAmmo -= 1;
        for(int i = 0; i < projectileCount; i++){
            GameObject newProjectile = Instantiate(projectilePrefab, spawnTransform.position, transform.rotation);  //https://docs.unity3d.com/ScriptReference/Transform.html
            newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * projectileSpeed;
            Destroy(newProjectile, lifeTime);
        }
        audioSource.pitch = Random.Range(1f-pitchRange,1f+pitchRange);
        audioSource.Play();
    }




    //Enemy can't fire constantly thanks to this
    void CoolDown(){
        coolingDown = true;
        StartCoroutine(CoolingDownRoutine());
        IEnumerator CoolingDownRoutine(){
            yield return new WaitForSeconds(coolDownTime);
            coolingDown = false;
        }
    }

}
