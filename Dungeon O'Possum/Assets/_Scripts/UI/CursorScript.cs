using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial: https://www.youtube.com/watch?v=5bSyIuMEjXE
//Attach this script to empty game object. 
namespace pocket.CustomCursor   {

    public class CursorControllerComplex : MonoBehaviour   {

        //Singlton 
        public static CursorControllerComplex Instance { get; private set; }
        
        [Header("Cursor Textures:")]//what the cursor looks like 
        [SerializeField] private Texture2D cursorTextureDefault;        
        [SerializeField] private Texture2D cursorTextureQuestion;        
        [SerializeField] private Texture2D cursorTextureExclaimation;        


        [Header("Cursor Click Position(s):")]
        [SerializeField] private Vector2 clickPosition = Vector2.zero;  //where the cursor is clicking (we want top left-ish)


        void Awake()  {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else { Destroy(gameObject); }
        }


        void Start()  {
            Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto); //on start, set cursor to this texture
        }



        public void SetToMode(ModeOfCursor moc)  {
            switch ( moc ) {
                case ModeOfCursor.Default:
                    Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
                    break;
                    
                case ModeOfCursor.Question:
                    Cursor.SetCursor(cursorTextureQuestion, clickPosition, CursorMode.Auto);
                    break;
                    
                case ModeOfCursor.Exclaimation:
                    Cursor.SetCursor(cursorTextureExclaimation, clickPosition, CursorMode.Auto);
                    break;
                    
                default:
                    Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
                    break;                    
            }
        }

        //Cursor Locking/Unlocking
        public void LockCursor() {  Cursor.lockState = CursorLockMode.Locked;  }
        public void UnlockCursor() {  Cursor.lockState = CursorLockMode.None;   }

        //Cursor Visability state
        public void MakeCursorVisable() {  Cursor.visible = true;  }
        public void MakeCursorInvisable() {  Cursor.visible = false;  }
    }

    //Enum for which texture we'll use for our cursor
    public enum ModeOfCursor {
        Default, 
        Question,
        Exclaimation
    }


/************************************************************************************************
    NOTES: 
        if cursor doesn't have its hotspot at the top left corner, use this: 
            -> change the clickPosition value in the inspector 
    
        if you want the cursor to be in the middle of the texture, use this: 
            -> new Vector2(cursorTexture.width * 0.5f, cursorTexture.height * 0.5f) sets it to the 
               center of the texture

        if we want to do an animated cursor, it might effect performance and we'd have to figure out 
        how to integrate it with different screen resolutions
************************************************************************************************/
}