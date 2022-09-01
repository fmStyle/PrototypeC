using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    PlayerData playerData;
    PlayerInventory playerInventory;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        playerInventory = GetComponent<PlayerInventory>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Mine(GameObject boulder){
        BoulderData boulderData = boulder.GetComponent<BoulderData>();
        if (playerData.strengthLevel < boulderData.necessaryStrength) return;
        
        playerMovement.Mine(boulder);
    }
    public void PickupDrop(GameObject drop){
        // foreach (ItemData item in playerInventory.items){
        //     if (item.id == drop.GetComponent<Drop>().itemdata.id){
        //         playerInventory.playerInventory.Add(item);
        //         return;
        //     }
        // }
        playerInventory.playerInventory.Add(drop.GetComponent<Drop>().itemdata);
    }
}
