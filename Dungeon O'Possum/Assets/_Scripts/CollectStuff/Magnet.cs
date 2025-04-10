using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial:
public class Magnet : MonoBehaviour  {

    private void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.TryGetComponent(out Coin coin)) {
            coin.SetTarget(transform.parent.position);
        }
        if (other.gameObject.TryGetComponent(out Fish fish)) {
            fish.SetTarget(transform.parent.position);
        }
    }
}
