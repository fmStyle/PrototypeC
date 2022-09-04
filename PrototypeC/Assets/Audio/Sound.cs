using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    
    public AudioClip clip;

    public GameObject owner;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;
    [Range(0f, 500f)]
    public float maxDistance;
    [Range(0f, 360f)]
    public float spread;

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
