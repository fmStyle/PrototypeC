using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed Data", menuName = "Seed Data")]
public class SeedData : ScriptableObject
{
    public int id;
    
    public Sprite spriteState0; // 0 would be the seed
    public Sprite spriteState1;
    public Sprite spriteState2;
    public Sprite spriteState3;
}
