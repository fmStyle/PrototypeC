using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OnDropManagerPlantplot : MonoBehaviour, IDropHandler
{
    public GameObject player;
    public GameObject plantplot;
    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<ItemUI>() != null){
            if (eventData.pointerDrag.GetComponent<ItemUI>().item.type != "stone") return;
            eventData.pointerDrag.transform.parent = gameObject.transform.Find("Container").transform;
            gameObject.transform.Find("Info").gameObject.GetComponent<TextMeshProUGUI>().text = eventData.pointerDrag.GetComponent<ItemUI>().item.name;
            FindObjectOfType<AudioManager>().Play("Use3");
            if (eventData.pointerDrag.GetComponent<ItemUI>().whereNow != "plantplot"){
                plantplot.GetComponent<Plantplot>().AddSeed(eventData.pointerDrag);
                // player.GetComponent<PlayerInventory>().RemoveItem(eventData.pointerDrag);

            }
        }
    }
}