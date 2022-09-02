using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int level;
    public int strengthLevel;
    public int velocityLevel;
    public int botanistLevel;
    public int pickaxeAbilityLevel;
    public int luckLevel;
    
    public int maxEnergy;
    public int energy;
    void Start()
    {
        level = 1;
        strengthLevel = 1;
        velocityLevel = 1;
        botanistLevel = 1;
        pickaxeAbilityLevel = 1;
        luckLevel = 1;
        maxEnergy = 30;
        energy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
