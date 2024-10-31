using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour  {
    
    [SerializeField] float speed = 5.0f;
    Vector3 movement = Vector3.zero;

    void Start()  {
        
    }


    //moves enemy 
    public void Move(Vector3 newMovement) {
        movement = newMovement;
        transform.localPosition += movement * speed * Time.deltaTime;
    }

    //
    public void MoveToward (Vector3 goalPos)  {
        goalPos.z = 0;
        Vector3 direction = goalPos - transform.position;
        Move(direction.normalized);
    }
    
    
}
