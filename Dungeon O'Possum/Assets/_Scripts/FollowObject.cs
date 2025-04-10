using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour  {

    [SerializeField] Transform following;
    [SerializeField] float smoothSpeed = 0.125f; 

    void LateUpdate()  {
        if (following != null) {
            Vector3 targetPosition = new Vector3(following.position.x, following.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
           // transform.LookAt(following);
        }
    }
}
