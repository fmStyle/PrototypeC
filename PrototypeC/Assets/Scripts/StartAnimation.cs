using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnimation : MonoBehaviour
{
    public GameObject FadeOut;
    Image fadeImage;
    bool fadedOut;
    public float durationInSeconds;
    float timer;
    // Start is called before the first frame update
    void Awake(){
        fadedOut = false;
        FadeOut.SetActive(true);
        GetComponent<PlayerMovement>().actionHappening = true;
        fadeImage = FadeOut.GetComponent<Image>();
    }
    void Start()
    {
        GameObject.FindWithTag("audiomanager").GetComponent<AudioManager>().Play("CasetteSound");
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadedOut){
            int a = (int)(((-255/(durationInSeconds))*timer) + (255));
            fadeImage.color = new Color32(0, 0, 0, (byte)(a));
            timer += Time.deltaTime;
            if (timer>=durationInSeconds){
                fadedOut = true;
                FadeOut.SetActive(false);
                GetComponent<PlayerMovement>().actionHappening = false;
            }
        }
    }
}
