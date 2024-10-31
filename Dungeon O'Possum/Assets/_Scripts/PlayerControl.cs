using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    
    [Header("Player:")]
    [SerializeField] Player player; 

    [Header("Animator:")]
    [SerializeField] Animator animator;   

    [Header("PlayerCombat:")]
    [SerializeField] PlayerCombat playCombat;   



    void Start() {
        animator = GetComponent<Animator>();
        playCombat = GetComponent<PlayerCombat>();
    }
    //WASD + arrowkey + joystick compatible 
    // void Update() { 

    //     // The value is in the range -1 to 1
    //     float updownInput = Input.GetAxis("Vertical") * speed; //-1 for up and +1 for down
    //     float sideInput = Input.GetAxis("Horizontal") * speed; //-1 for left and +1 for right

    //     // Make it move 10 meters per second instead of 10 meters per frame...
    //     updownInput *= Time.deltaTime;
    //     sideInput *= Time.deltaTime;

    //     //use transform.translate to interpret player's movement
    //     transform.Translate(0, updownInput, 0);
    //     transform.Translate(sideInput, 0, 0);
    // }




    void FixedUpdate() {
        Vector3 movement = Vector3.zero;
        animator.SetInteger("Verticle", 0); 
        animator.SetInteger("Horizontal", 0); 
        playCombat.isMoving = false; 
        
        if (Input.GetKey(KeyCode.W)) {              //W = up
            movement += new Vector3(0, 1, 0);
            animator.SetInteger("Verticle", 1); 
            playCombat.facingDirection = 0; 
            playCombat.isMoving = true; 
        }
        if (Input.GetKey(KeyCode.S)) {              //S = down
            movement += new Vector3(0, -1, 0);
            animator.SetInteger("Verticle", -1); 
            playCombat.facingDirection = 1; 
            playCombat.isMoving = true; 
        }
        if (Input.GetKey(KeyCode.A)) {              //A = left  
            movement += new Vector3(-1, 0, 0);
            animator.SetInteger("Horizontal", -1); 
            playCombat.facingDirection = 2; 
            playCombat.isMoving = true; 
        }
        if (Input.GetKey(KeyCode.D)) {              //D = right
            movement += new Vector3(1, 0, 0);
            animator.SetInteger("Horizontal", 1); 
            playCombat.facingDirection = 3; 
            playCombat.isMoving = true; 
        }
        
        //*** TO DO: SPRINT/DODGE MECHANIC


        player.Move(movement);
    }
}

