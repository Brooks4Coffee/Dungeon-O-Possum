using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour  {
    [Header("Animation")]
    [SerializeField] EnemyAi1 enAI;
    [SerializeField] float idleDuratation;
    [SerializeField] float patrolDuration;
    [SerializeField] float idleTimer = 0.0f;
    [SerializeField] float patrolTimer = 0.0f;


    [Header("Animation")]
    [SerializeField] Animator animator; 
    Vector3 lastDir = Vector3.zero;
    int vertical = 0;
    int horizontal = 0;

    [Header("Movement Configuration")]
    [SerializeField] float speed = 5.0f;
    Vector3 movement = Vector3.zero;

    void Start() {
        idleTimer = 0.0f;
        patrolTimer = 0.0f;
        idleDuratation = enAI.GetIdleTime();    //grab idle time
        patrolDuration = enAI.GetPatrolTime();  //grab patrol time
    }

    //depending on where we're mostly going, will set animation triggers accordingly (used tutorial)
    void SetAnimationTriggers(Vector3 dir)  {
        if (animator == null) return; //unsurprisingly: if no animator, then no animations

        if (dir.magnitude > 0.1f) { lastDir = dir; }

        // Reset parameters
        int horizontal = 0;
        int vertical = 0;


        //Set animation triggers according to which direction we're mostly facing
        if (Mathf.Abs(lastDir.x) > Mathf.Abs(lastDir.y)) {          //may need to switch y to z since we're isometric
            horizontal = lastDir.x > 0 ? 1 : -1;
        }
        else {
            vertical = lastDir.y > 0 ? 1 : -1;
        }       
            animator.SetInteger("Horizontal", horizontal);
            animator.SetInteger("Verticle", vertical);  //spelling mistake smh
    }


    //moves enemy if chasing player
    public void MoveToward (Vector3 goalPos)  {
        goalPos.z = 0;
        Vector3 direction = goalPos - transform.position;
        Move(direction.normalized);
    }
    
    //moves enemy in patrol state
    public void Move(Vector3 newMovement) {
        movement = newMovement;
        transform.localPosition += movement * speed * Time.deltaTime;
        SetAnimationTriggers(movement);
    }
    
}
