using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDropManagerPlantplot : MonoBehaviour, IDropHandler
{
    public GameObject player;
    public GameObject plantplot;
    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null){
            if (eventData.pointerDrag.GetComponent<ItemUI>().item.type != "stone") return;
            eventData.pointerDrag.transform.parent = gameObject.transform.Find("Container").transform;
            if (eventData.pointerDrag.GetComponent<ItemUI>().whereNow != "plantplot"){
                plantplot.GetComponent<Plantplot>().AddSeed(eventData.pointerDrag);
                
                // player.GetComponent<PlayerInventory>().RemoveItem(eventData.pointerDrag);

            }
        }
    }
}