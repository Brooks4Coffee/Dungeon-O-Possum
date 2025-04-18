using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    
    [Header("Player:")]
    [SerializeField] Player player; 
	[SerializeField] public bool isInMinigame = false;

    [Header("Animator:")]
    [SerializeField] Animator animator;   

    [Header("PlayerCombat:")]
    [SerializeField] PlayerCombat playCombat;   



    void Start() {
        animator = GetComponent<Animator>();
        playCombat = GetComponent<PlayerCombat>();
    }

    
    //WASD + arrowkey + joystick compatible 
    void FixedUpdate() {
		if (isInMinigame) { return; }
        bool areWeSprinting = false; 
        playCombat.isMoving = false; 

        Vector3 movement = Vector3.zero;
        float v_input = Input.GetAxis("Vertical");
        float h_input = Input.GetAxis("Horizontal"); 
        animationHandler(v_input, h_input); 
        movement += new Vector3(h_input, v_input, 0);
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(1)) {
            player.SetDamageableStatus(false);
            areWeSprinting = true;
        }
        else { player.SetDamageableStatus(true); } //if we aren't sprinting/dodging, then we're damageable

        player.Move(movement, areWeSprinting);
    }


    void animationHandler(float v_input, float h_input) {
        animator.SetInteger("Verticle", 0); 
        animator.SetInteger("Horizontal", 0); 
        if (v_input > 0) {              //W = up
            animator.SetInteger("Verticle", 1); 
            playCombat.facingDirection = 0; 
            playCombat.isMoving = true; 
        }
        if (v_input < 0) {              //S = down
            animator.SetInteger("Verticle", -1); 
            playCombat.facingDirection = 1; 
            playCombat.isMoving = true; 
        }
        if (h_input < 0) {              //A = left  
            animator.SetInteger("Horizontal", -1); 
            playCombat.facingDirection = 2; 
            playCombat.isMoving = true; 
        }
        if (h_input > 0) {              //D = right
            animator.SetInteger("Horizontal", 1); 
            playCombat.facingDirection = 3; 
            playCombat.isMoving = true; 
        }
    }
    public void OutOfGame(){
        isInMinigame = false; 
    }
}

