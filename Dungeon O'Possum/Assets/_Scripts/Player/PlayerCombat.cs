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
    [SerializeField] public bool isAttack; 
    [SerializeField] PlayerControl pc; 

    [Header("Audio:")]
    [SerializeField] AudioClip audioClip_Sword; 
    [SerializeField] AudioSource audioSource_Sword;
    [Range(0, 1)]
    [SerializeField] float pitchRange = 0.2f;

    [Header("Attack Configurations:")]
    [SerializeField] float timeBetweenAttacks = 0.25f; 
    [SerializeField] Transform attackPoint;                 //local point on player where we attack from
    [SerializeField] float attackRange = 0.5f;              //radius range of our attacks
    [SerializeField] float attackDamage = 25.0f;            //how much damage we do on attack 
    [SerializeField] float attackTimeCounter = 0.0f; 
    public bool ShouldBeDamaging { get; set; } = false; 
    private List<IDamageable> iDamageables = new List<IDamageable>(); 
    public LayerMask enemyLayers;                           //layer to detect enemies

    [SerializeField] public bool diagonal = false;
    [SerializeField] public string direction = "None";

    private void Start()
    {
        //animator = GetComponent<Animator>();  //was causing issues for some reason
        attackTimeCounter = timeBetweenAttacks; 
        isAttack = false; 
    }

    //NOTE: Something going on with attack animation not going into effect when walking animation/movement is happening
    //      gotta figure out a fix for that... 
    void Update() {
        attackTimeCounter += Time.deltaTime;
		if (pc.isInMinigame) { return; }
        if ((Input.GetMouseButtonDown(0)) && (attackTimeCounter >= timeBetweenAttacks) ) {   //check for left mouse click and timer
            //TODO: figure out how to add moving attacks... 
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 attackDirection = (mousePosition - transform.position).normalized;
            TriggerAttackAnimations();
            Attack(attackDirection);
            attackTimeCounter = 0.0f; 
        }
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

        Debug.Log(diagonal);
        if (diagonal && direction == "Up")
        {
            animator.SetTrigger("Attack_Up");
        }
        else if (diagonal && direction == "Down")
        {
            animator.SetTrigger("Attack_Down");
        }
        else
        {
            switch (facingDirection)
            {                     //set trigger based on direction
                case 0:
                    animator.SetTrigger("Attack_Up");
                    break;
                case 1:
                    animator.SetTrigger("Attack_Down");
                    break;
                case 2:
                    animator.SetTrigger("Attack_Left");
                    animator.SetBool("Left", true);     //that way we go to left instead of idle(right)
                    break;
                case 3:
                    animator.SetTrigger("Attack");
                    break;
                default:
                    break;
            }
        }
        
        audioSource_Sword.pitch = Random.Range((1.0f - pitchRange), (1.0f + pitchRange)); //noise
        audioSource_Sword.Play(); 
    }



    /*
     * 
     */  
    void Attack(Vector3 attackDirection) {
        StartCoroutine(DamageWhileSlashIsActive());
        IEnumerator DamageWhileSlashIsActive() {
            ShouldBeDamaging = true; 
            while(ShouldBeDamaging) {
                RaycastHit2D[] hits = Physics2D.CircleCastAll(attackPoint.position, attackRange, (Vector2)attackDirection, 0f, enemyLayers);    //detect enemies in range of attack
                for (int i = 0; i < hits.Length; i++) {    //Apply damage to those enemies
                    IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();
                    if (iDamageable != null && !iDamageables.Contains(iDamageable)) {
                        Debug.Log("We Hit " + iDamageable); 
                        iDamageable.TakeDamage(attackDamage, (Vector2)attackDirection);
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