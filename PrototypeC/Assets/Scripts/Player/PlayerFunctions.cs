using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    PlayerData playerData;
    PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        playerInventory = GetComponent<PlayerInventory>();
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
    public void PickupDrop(GameObject drop){
        foreach (ItemData item in playerInventory.items){
            if (item.id == drop.GetComponent<Drop>().id){
                playerInventory.playerInventory.Add(item);
                return;
            }
        }
    }
}
