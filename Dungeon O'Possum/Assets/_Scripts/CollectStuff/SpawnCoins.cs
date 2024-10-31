using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour  {

    [Header("Prefab:")]
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject Asteroid;
    [SerializeField]float spawnForce = 10f;      // Force with which coins will bounce out
  


    /*
     * Spawns Coins random number of times (1-5) where given transform just was
     */
    public void SpawnLoot (Transform transform, Vector2 attackDirection) {
        int rand = Random.Range(1, 5);
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, attackDirection);
        for (int i = 0; i < rand; i++) {
            GameObject coin = Instantiate(coinPrefab,  transform.position, spawnRotation);    
            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
            //Vector2 randomDirection = Random.insideUnitCircle.normalized;   // Random 2D direction
            rb.AddForce(attackDirection * spawnForce, ForceMode2D.Impulse); // send it off a bit
        }
        
    }

}
