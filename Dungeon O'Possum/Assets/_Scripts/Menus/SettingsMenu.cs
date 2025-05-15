using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

//Tutorial Used: https://www.youtube.com/watch?v=YOaYQrN1oYQ 
public class SettingsMenu : MonoBehaviour  {
    [Header("Audio:")]
    [SerializeField] AudioMixer masterAudioMixer;

    [Header("TextMeshPro:")]
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] TMPro.TMP_Dropdown qualityDropdown; 

    //other
    public Resolution[] resolutions; 



    /*
     * Figures out all the resolutions available to our program per computer.
     */
    void Start() {
        resolutions = Screen.resolutions;               //grab resolutions that the current PC can handle
        try {resolutionDropdown.ClearOptions();   }              //Clear Default Options on our dropdown 
      
        catch(Exception) {}
        
        
        //since we can't add resolutions directly to our Dropdown, we first convert them into a list of strings
        List<string> options = new List<string>();
        int currentResolutionIndex = 0; //for setting default size
        for (int i = 0; i < resolutions.Length; i++) {
            //string option = resolutions[i].width + " x " + resolutions[i].height + ", " + resolutions[i].refreshRateRatio + "Hz";
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            //Check for best size to set as default
            if ((resolutions[i].height == Screen.currentResolution.height) && (resolutions[i].width == Screen.currentResolution.width)) {
                currentResolutionIndex = i; 
            }
        }

		SetMasterVolume(0.5f);
    	SetMusicVolume(1f);
    	SetUIVolume(1f);
    	SetSFXVolume(1f);
    	SetAmbientVolume(1f);

        resolutionDropdown.AddOptions(options);             // takes List<string> argument
        resolutionDropdown.value = currentResolutionIndex;  // set current resolution to our default resolution
        resolutionDropdown.RefreshShownValue();             // refresh to see our default resolution

        //Now we set Graphics Default to Very High :D
        qualityDropdown.value = 4;                  // set current graphics quality to a default
        qualityDropdown.RefreshShownValue();        // Refresh to see our default graphics quality
    }



    public void SetMasterVolume(float volume)  {              
        masterAudioMixer.SetFloat("Volume_Master", Mathf.Log10(volume) * 20);    //WORKING VERSION: keeps in mind non-linear audiomixer. 
    }

    public void SetMusicVolume(float volume)  {
        masterAudioMixer.SetFloat("Volume_Music", Mathf.Log10(volume) * 20);    //WORKING VERSION: keeps in mind non-linear audiomixer. 
    }

    public void SetUIVolume(float volume)  {
        masterAudioMixer.SetFloat("Volume_UI", Mathf.Log10(volume) * 20);    //WORKING VERSION: keeps in mind non-linear audiomixer. 
    }
    public void SetSFXVolume(float volume)  {
        masterAudioMixer.SetFloat("Volume_SFX", Mathf.Log10(volume) * 20);    //WORKING VERSION: keeps in mind non-linear audiomixer. 
    }

    public void SetAmbientVolume(float volume)  {
        masterAudioMixer.SetFloat("Volume_Ambient", Mathf.Log10(volume) * 20);    //WORKING VERSION: keeps in mind non-linear audiomixer. 
    }



    /*
     * Sets the quality of our game. We have 6 different levels to choose from (for funsies)
     * Index Levels:      
     *      0 - Very Low        = works
     *      1 - Low             = works
     *      2 - Medium          = works
     *      3 - High            = works
     *      4 - Very High       = works
     *      5 - ULTRA (default) = works
     */
    public void SetGraphics(int qualityIndex)  {
        //Debug.Log(); 
        QualitySettings.SetQualityLevel(qualityIndex);
    }    


    /*
     * Sets Fullscreen based on bool. 
     *      - if user wants fullscreen, they send true via switching on the toggle
     *      - if user doesn't want fullscreen, they send false via switching off the toggle
     */
    public void SetFullscreen(bool isFullscreen)  {
        //Debug.Log("User Chose: " + isFullscreen); 
        Screen.fullScreen = isFullscreen;   
    }  


    /*
     * Sets Resoluton based on int. 
     */
    public void SetResolution(int resolutionIndex)  {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }  
}
