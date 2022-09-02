using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using System;

public class BedScript : MonoBehaviour
{
    public GameObject player;
    public GameObject minecart;
    public GameObject fadePanel;
    Image fadeImage;
    float illuminationValue;
    public float sleepingDuration;
    public float minecartAnimationSpeed;
    public float minecartAnimationAcceleration;
    float minecartAnimationSpeedOriginal;
    float minecartAnimationAccelerationOriginal;
    Vector2 minecartPosition;
    float timer;
    Vector3 t;
    Vector3 firstHalf;
    Vector3 secondHalf;
    Vector3 final;
    private void Awake(){

        final = new Vector3(sleepingDuration, 0, 0);
        fadeImage = fadePanel.GetComponent<Image>();
        minecartAnimationAccelerationOriginal = minecartAnimationAcceleration;
        minecartAnimationSpeedOriginal = minecartAnimationSpeed;
        minecartPosition = new Vector2(minecart.transform.position.x, minecart.transform.position.y);
    }
    public void Sleep(){
        
        player.GetComponent<PlayerMovement>().actionHappening = true;
        if (timer<sleepingDuration/2){
            int a = (int)((255/((sleepingDuration/2)))*timer);
            fadeImage.color = new Color32(0, 0, 0, (byte)(a));
            minecart.transform.position = new Vector3(minecart.transform.position.x, minecart.transform.position.y + (minecartAnimationSpeed * Time.deltaTime), 0);
            minecartAnimationSpeed += (minecartAnimationAcceleration * Time.deltaTime);
        } 
        else {
            player.GetComponent<PlayerData>().energy = GetComponent<PlayerData>().maxEnergy;
            minecart.transform.position = minecartPosition;
            int a = (int)((-255/(sleepingDuration-(sleepingDuration/2)))*timer) + (255*2);
            fadeImage.color = new Color32(0, 0, 0, (byte)(a));
        }

        timer+=Time.deltaTime;
        if (timer > sleepingDuration){
            player.GetComponent<PlayerMovement>().actionHappening = false;
            timer = 0;
            minecartAnimationAcceleration = minecartAnimationAccelerationOriginal;
            minecartAnimationSpeed = minecartAnimationSpeedOriginal;
            minecart.GetComponent<MinecartInventory>().CleanInventoryAndPayPlayer(player);
        }
    }
}
