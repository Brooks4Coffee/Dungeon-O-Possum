using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour  {

    [SerializeField] Transform objToFlwTrnsfrm;

    void Update()  {
        if (objToFlwTrnsfrm != null) {
            transform.position = new Vector3(objToFlwTrnsfrm.position.x, objToFlwTrnsfrm.position.y, -10);
        }
    }
}
