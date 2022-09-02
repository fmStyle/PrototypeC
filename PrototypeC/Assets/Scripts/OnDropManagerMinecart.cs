using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OnDropManagerMinecart : MonoBehaviour, IDropHandler
{
    public GameObject player;
    public GameObject minecart;
    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null){
            Debug.Log("WORKING!");
            eventData.pointerDrag.transform.parent = gameObject.transform.Find("Viewport").transform.Find("Content").transform;
            if (eventData.pointerDrag.GetComponent<ItemUI>().whereNow == "inventory"){
                minecart.GetComponent<MinecartInventory>().AddItem(eventData.pointerDrag);
                
                player.GetComponent<PlayerInventory>().RemoveItem(eventData.pointerDrag);

            }
        }
    }
}