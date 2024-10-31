using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour  {
    
    [Header("Pause Menu:")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject HUD;
    [SerializeField] bool GameIsPaused = false;

    [Header("Player:")]
    [SerializeField] Player player; 

    [Header("Scene Transition:")]
    [SerializeField] Animator fadeTransition; 


    /*
     * checks for escape key being pressed
     */
    void Update()  {
        if (Input.GetKeyDown(KeyCode.Escape)) {  //if we press esc button, pause/resume based on current status. 
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    /*
     * Getter for pause state (are we paused or not)
     */
    public bool GetPauseState() {
        return GameIsPaused;
    }

    /*
     * Resumes game
     */
    public void Resume() {
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1.0f; 
        GameIsPaused = false;
    }


    /*
     * Pauses game
     */
    public void Pause() {
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0.0f; 
        GameIsPaused = true; 
    }

    /*
     * sends us to main menu
     */
    public void GoToMainMenu() {
        Debug.Log("Going to Main Menu");
        SceneManager.LoadScene("0_MainMenu");
        //StartCoroutine(LoadMenu());
    } 

    // //fix bugs
    // private IEnumerator LoadMenu()    {
    //     fadeTransition.SetTrigger("End");
    //     yield return new WaitForSeconds(1.5f);
    //     SceneManager.LoadScene("0_MainMenu");
    // }
    
    // /*
    //  * Go Back To The Adventerers' Guild
    //  */
    // public void GoBackToGuild() {
    //     Debug.Log("Going Back To Adventurer's Guild");
    //     StartCoroutine(LoadGuild());
    //     IEnumerator LoadGuild() {
    //         fadeTransition.SetTrigger("End"); 
    //         yield return new WaitForSeconds(1.5f); 
    //         SceneManager.LoadScene("AdventerersGuild");
    //     }
    // }



    /*
     * Save Game Progress
     */
    public void SaveGame() {
        Debug.Log("You've Saved!");
        SaveSystem.SavePlayer(player);
    }



    /*
     * Load Previous Game Progress
     */
    public void LoadGame() {
        PlayerData data = SaveSystem.LoadPlayer();

        player.level = data.level; 
        player.XP = data.XP;

        player.health.SetMaxHealth(data.maxHealth);  
        player.health.SetCurrentHealth(data.currentHealth); 

        Vector3 position;
        position.x = data.position[0]; 
        position.y = data.position[1]; 
        position.z = data.position[2]; 
        player.GetComponent<Transform>().position = position; 
    }
}
