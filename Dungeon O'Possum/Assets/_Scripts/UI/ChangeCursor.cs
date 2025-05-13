using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Tutorial: https://www.youtube.com/watch?v=5bSyIuMEjXE
//Attach this script to game object that the cursor will change textures when hovering over it. 


/************************************************************************************************
    NOTES: 
        if hooking this up to UI element, just make sure there's an event system in place and you're good to go.
        However,
        if you're hooking this up to an in-game object, you need an appropriate collider
            -> Polygon Collider 2D
        and the camera needs the corresponding Physics 2D or 3D Raycaster depending if game is 2D or 3D

************************************************************************************************/
namespace pocket.CustomCursor   {

    public class ChangeCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler    {
        
        [Header("Cursor Mode:")]
        [SerializeField] private ModeOfCursor moc; 


        //When Cursor hovers over gameobject
        public void OnPointerEnter(PointerEventData eventData)   {
            CursorControllerComplex.Instance.SetToMode(moc);
        }

        //When Cursor moves away from gameobject
        public void OnPointerExit(PointerEventData eventData)   {
            CursorControllerComplex.Instance.SetToMode(ModeOfCursor.Default);
        }
    }


}