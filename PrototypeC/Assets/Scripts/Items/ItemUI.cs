using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemUI : MonoBehaviour
{
    public ItemData item;
    public GameObject player;
    public string whereNow;
    GameObject button;
    void Start(){
        player = GameObject.FindGameObjectWithTag("player");
        button = gameObject.transform.Find("RemoveButton").gameObject;
        button.GetComponent<Button>().onClick.AddListener(delegate {player.GetComponent<PlayerInventory>().RemoveItem(gameObject);});
    }
}
