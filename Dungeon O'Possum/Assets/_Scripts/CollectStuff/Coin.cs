using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial Used: https://www.youtube.com/watch?v=f75Wcwu33OY
public class Coin : MonoBehaviour, ICollectable   {

    //public static event Action OnCoinCollected;       //Event *** TO DO: Set Up Audio Manager to play coin collected noise
    Rigidbody2D rb;
    bool hasTarget;
    Vector3 targetPosition;
    [SerializeField] float moveSpeed = 5.0f;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

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


    // Update is called once per frame
    public void Collect()  {
        Debug.Log("Coin Collected");
        Destroy(gameObject);
        //OnCoinCollected?.Invoke();    //for event listeners
    }
}
