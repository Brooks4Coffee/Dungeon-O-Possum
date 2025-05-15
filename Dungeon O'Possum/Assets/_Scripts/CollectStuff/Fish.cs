using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorials Used: https://www.youtube.com/watch?v=f75Wcwu33OY
//                https://www.youtube.com/watch?v=geq7lQSBDAE
public class Fish : MonoBehaviour, ICollectable  {
    
    public static event HandleFishCollection onFishCollected;           //Event
    public delegate void HandleFishCollection(ItemData item);           //delegate 
    public ItemData fishData;                                           //reference
    Vector3 targetPosition;
    [SerializeField] float moveSpeed = 5.0f;
    bool hasTarget;
    Rigidbody2D rb;




    private void Awake() { rb = GetComponent<Rigidbody2D>();  }

    private void FixedUpdate() {
        if (hasTarget) {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;
        }
    }

    public void SetTarget(Vector3 position) {
        targetPosition = position;
        hasTarget = true; 
    }

    public void Collect() {
        Destroy(gameObject);
        onFishCollected?.Invoke(fishData);
    }
}
