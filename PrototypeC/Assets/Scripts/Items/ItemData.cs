using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public float cost;
    public Sprite sprite;
}
