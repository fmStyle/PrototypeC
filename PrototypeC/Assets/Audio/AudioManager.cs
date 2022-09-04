using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){

            if (s.owner == null){
                s.source = gameObject.AddComponent<AudioSource>();
            } 
            else{
                s.source = s.owner.AddComponent<AudioSource>();
            }
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.dopplerLevel = 0;
            s.source.maxDistance = s.maxDistance;
            s.source.spread = s.spread;
            s.source.playOnAwake = s.playOnAwake;
            // if (s.owner != null){
            //     s.owner.AddComponent<AudioSource>();
            //     s.owner.GetComponent<AudioSource>() = s.source;
            //     // sounds.Add(s.owner)
            // }
        }
    }

    public void Play(string name){

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogError("Name doesn't match with any of the existing sounds :(");
        }
        else s.source.Play();
        
    }

    public void Stop(string name){

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogError("Name doesn't match with any of the existing sounds :(");
        }
        s.source.Stop();
        
    }
    public void Pause(string name){

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogError("Name doesn't match with any of the existing sounds :(");
        }
        s.source.Pause();
        
    }
    public AudioSource GetAudioSource(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogError("Name doesn't match with any of the existing sounds :(");
            return null;
        }
        return s.source;
    }
    public void ModifyVolume(string name, float newValue){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogError("Name doesn't match with any of the existing sounds :(");
            // return null;
        }
        s.source.volume = newValue;
    }
}
