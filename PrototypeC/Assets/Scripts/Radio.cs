using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioManager audioManager;
    public string[] songsRadio;
    int songIndex;
    bool turnedOn;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        songIndex = 0;
        audioManager.Play(songsRadio[songIndex]);
        turnedOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnedOn){
            if (!audioManager.GetAudioSource(songsRadio[songIndex]).isPlaying){
                GoNextClip();
            }
        }
    }
    void GoNextClip(){
        songIndex++;
        if (songIndex == songsRadio.Length){
            songIndex = 0;
            audioManager.Play(songsRadio[songIndex]);
        } else{
            audioManager.Play(songsRadio[songIndex]);
            audioManager.Stop(songsRadio[songIndex-1]);
        }
    }
    public AudioSource ActualSongPlaying(){
        return audioManager.GetAudioSource(songsRadio[songIndex]);
    }
    public void TurnOffRadio(){
        audioManager.Pause(songsRadio[songIndex]);
        audioManager.Play("RadioTurn");
        turnedOn = false;
    }   
    public void TurnOnRadio(){
        audioManager.Play(songsRadio[songIndex]);
        audioManager.Play("RadioTurn");
        turnedOn = true;
    }
    public bool IsTurnedOn(){
        return turnedOn;
    }
}
