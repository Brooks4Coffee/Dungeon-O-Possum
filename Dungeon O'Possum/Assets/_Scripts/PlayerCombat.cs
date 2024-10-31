using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//Tutorials Used: https://www.youtube.com/watch?v=sPiVz1k-fEs 
//                
//                
public class PlayerCombat : MonoBehaviour  {
    
    [Header("Player Configurations:")]
    [SerializeField] Animator animator;             //animator
    [SerializeField] public int facingDirection = 3; //auto set to right
    [SerializeField] public int prevfacingDirection = 3; //auto set to right
    [SerializeField] public bool isMoving; 


    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [Range(0,1)]
    [SerializeField] float pitchRange = .2f;


    [Header("Attack Configurations::")]
    [SerializeField] float timeBetweenAttacks = 0.25f; 
    [SerializeField] Transform attackPoint;                 //local point on player where we attack from
    [SerializeField] float attackRange = 0.5f;              //radius range of our attacks
    [SerializeField] float attackDamage = 25.0f;            //how much damage we do on attack 
    public LayerMask enemyLayers;                           //layer to detect enemies
    private float attackTimeCounter = 0.0f; 
    public bool ShouldBeDamaging { get; set; } = false; 
    private List<IDamageable> iDamageables = new List<IDamageable>(); 



    private void Start() {
        animator = GetComponent<Animator>();  //was causing issues for some reason
        attackTimeCounter = timeBetweenAttacks; 
        isMoving = false; 
    }

    
    void Update()  {
        // if (!isMoving) {    //if we're not moving, set trigger to right animation
        //     if (facingDirection == 2){
        //         facingDirection = 2; // Default to left
        //         animator.SetBool("Left", true);
        //     } 
        //     else {
        //         facingDirection = 3; // Default to right
        //         animator.SetBool("Left", false);
        //     }
        // }
        if ((Input.GetMouseButtonDown(0)) && (attackTimeCounter >= timeBetweenAttacks)) {   //check for left mouse click and timer
            TriggerAttackAnimations();
            Attack();
            attackTimeCounter = 0.0f; 
        }
        attackTimeCounter += Time.deltaTime; 
    }


    //input is multiplier for attack
    public void BlessAttack(float attackMultiplier) {
        attackDamage = attackDamage * attackMultiplier; 
    }



    /*
     * Based on what direction we're facing, launch attack there
     *      0 -  Up
     *      1 -  Down
     *      2 -  Left
     *      3 -  Right
     */ 
    private void TriggerAttackAnimations() {
        switch(facingDirection) {                     //set trigger based on direction
            case 0: 
                animator.SetTrigger("Attack_Up");
                break; 
            case 1: 
                animator.SetTrigger("Attack_Down");
                break; 
            case 2:
                animator.SetTrigger("Attack_Left");
                animator.SetBool("Left", true);
                break; 
            case 3: 
                animator.SetTrigger("Attack");
                break; 
            default: 
                break; 
        }
    }



    /*
     * 
     */  
    void Attack() {
        StartCoroutine(DamageWhileSlashIsActive());
        IEnumerator DamageWhileSlashIsActive() {
            ShouldBeDamaging = true; 
            while(ShouldBeDamaging) {
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);    //detect enemies in range of attack
                int i = 0;
                foreach(Collider2D enemy in hitEnemies) {       //Apply damage to those enemies
                    IDamageable iDamageable = hitEnemies[i].GetComponent<Collider2D>().gameObject.GetComponent<IDamageable>();
                    if (iDamageable != null && !iDamageables.Contains(iDamageable)) {
                        Debug.Log("We Hit " + enemy); 
                        //*** TO DO: Figure out how to fix the sending transform to send the attack direction. 
                        enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage, transform.right);
                        iDamageables.Add(iDamageable); //add it to list
                    }
                    i++;
                }                
                yield return null; 
            }
        }
        iDamageables.Clear();
    }
        

    /*
     * Shows us our attack range while we work in editor
     */
    void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return; 
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    #region Animation Triggers
    /*
     * Based on where we are in animation, trigger will occur and set these to true or false. 
     */
    public void ShouldBeDamaging_ToTrue() {  ShouldBeDamaging = true;  }
    public void ShouldBeDamaging_ToFalse() {  ShouldBeDamaging = false;  }
    #endregion
}