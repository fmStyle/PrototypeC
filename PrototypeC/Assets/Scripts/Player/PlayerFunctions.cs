using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pick(GameObject boulder){
        BoulderData boulderData = boulder.GetComponent<BoulderData>();
        if (playerData.strengthLevel < boulderData.necessaryStrength) return;
        boulderData.durability -= playerData.pickaxeAbilityLevel * 20.0f;
    }
}
