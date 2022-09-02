using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyLength : MonoBehaviour
{
    RectTransform rectTransform;
    public PlayerData playerData;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        rectTransform.sizeDelta = new Vector2((150/30)*playerData.energy, 50);
    }
}
