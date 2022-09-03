using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDropManagerInventory : MonoBehaviour, IDropHandler
{
    public GameObject minecart;
    public GameObject player;
    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null){
            eventData.pointerDrag.transform.parent = gameObject.transform.Find("Viewport").transform.Find("Content").transform;
            if (eventData.pointerDrag.GetComponent<ItemUI>().whereNow != "inventory"){
                player.GetComponent<PlayerInventory>().AddItem(eventData.pointerDrag);
                minecart.GetComponent<MinecartInventory>().RemoveItem(eventData.pointerDrag);
            }
        }
    }
}