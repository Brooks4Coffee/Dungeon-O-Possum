using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//let's us find and talk to NPCs easily
public class InteractionInstigator : MonoBehaviour  {
    private List<Interactable> nearbyInteractables = new List<Interactable>();

    //check for nearby NPCs we can talk to
    public bool HasNearbyInteractables()    { return nearbyInteractables.Count != 0; }

    private void Update()  {
        //Ideally, we'd want to find the best possible interaction (ex: by distance & orientation).
        if (HasNearbyInteractables() && Input.GetButtonDown("Submit"))  {
            nearbyInteractables[0].DoInteraction();
        }
    }

    //when entering collider, add NPC to the list of NPCs we can interact with at current moment
    private void OnTriggerEnter(Collider other)   {
        Debug.Log("Entered Collider!");
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)  {  
            Debug.Log("Finally! Someone to talk to!");
            nearbyInteractables.Add(interactable); 
        }
    }

    //when leaving collider, take NPC off of list of NPCs we can interact with at current moment
    private void OnTriggerExit(Collider other)  {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null) { nearbyInteractables.Remove(interactable); }
    }
}
