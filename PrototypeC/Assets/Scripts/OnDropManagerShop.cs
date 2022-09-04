using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDropManagerShop : MonoBehaviour, IDropHandler
{
    public GameObject player;
    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<ItemUI>() != null){
            PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
            ItemData itemData = eventData.pointerDrag.GetComponent<ItemUI>().item;
            float sellPrice = itemData.costToSellToNPC;
            Debug.Log(sellPrice);
            playerInventory.RemoveItem(eventData.pointerDrag);
            playerInventory.AddMoney(sellPrice);
            
            // player.GetComponent<PlayerInventory>().RemoveItem(eventData.pointerDrag);

        }
    }
}