using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour  {
    [SerializeField] float size = 0.44f;
    [SerializeField] float minColorVal = 0.25f;
    [SerializeField] float maxColorVal = 0.5f;
    [SerializeField] GameObject asteroidPrefab;
    SpriteRenderer spriteRenderer;

    void Awake()  {
        spriteRenderer = GetComponent<SpriteRenderer>();
        RandomizeColor();
    }


     public void RandomizeColor(){
        spriteRenderer.color = new Color(Random.Range(minColorVal,maxColorVal), Random.Range(minColorVal,maxColorVal), Random.Range(minColorVal,maxColorVal));
    }
}
