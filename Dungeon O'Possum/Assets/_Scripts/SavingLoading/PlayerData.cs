using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData  {
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public int level;
    [SerializeField] public int XP;
    [SerializeField] public float[] position;  //equivelent to Vector3

    public PlayerData(Player player) {
        Health health = player.GetHealth();
        maxHealth = health.GetMaxHealth();
        currentHealth = health.GetCurrentHealth();
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }



}
