using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
//basically: put this on NPC that we can talk to. we keep a list of those nearby player that's updated regularly
public class Interactable : MonoBehaviour  {
    [SerializeField]  UnityEvent onInteraction;
    public void DoInteraction()  {  onInteraction.Invoke(); }
}
