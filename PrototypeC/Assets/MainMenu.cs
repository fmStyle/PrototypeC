using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Awake(){
        
    }
    public void PlayGame()
    {
        PlayUseSound();
        SceneManager.LoadScene("MainGameScene");
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void PlayUseSound(){
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Use1");
    }

    public void FullScreen(){
        PlayUseSound();
        Screen.fullScreen = !Screen.fullScreen;
    }
}
