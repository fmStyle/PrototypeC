using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    int actualState;
    SpriteRenderer spriteRenderer;
    public SeedData plantedSeed;
    bool planted;
    void Start(){
        actualState = -1;
        planted = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void StartState(){
        planted = true;
        actualState = 0;
        spriteRenderer.sprite = plantedSeed.spriteState0;
    }
    public void NextState(){
        if (actualState == 3) return;
        switch(ActualState()){
            case (0):
            {
                spriteRenderer.sprite = plantedSeed.spriteState1;
                break;
            }
            case (1):
            {
                spriteRenderer.sprite = plantedSeed.spriteState2;
                break;
            }
            case (2):
            {
                spriteRenderer.sprite = plantedSeed.spriteState3;
                break;
            }
        }
        actualState++;
    }
    public bool isPlanted(){
        return planted;
    }
    public int ActualState(){
        return actualState;
    }
    public void Harvest(){
        actualState = -1;
        planted = false;
        spriteRenderer.sprite = null;
    }
}
