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
    void Start()
    {
        level = 1;
        strengthLevel = 1;
        velocityLevel = 1;
        botanistLevel = 1;
        pickaxeAbilityLevel = 1;
        luckLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
