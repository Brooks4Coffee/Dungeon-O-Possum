using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour  {

    private void OnTriggerStay2D (Collider2D other) {
        if (other.CompareTag("Collectable")) {
            other.GetComponent<Coin>().SetTarget(transform.parent.position);
        }
    }
}
