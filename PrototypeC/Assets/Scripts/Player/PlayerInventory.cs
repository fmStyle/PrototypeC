using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    // public List<ItemData>items = new List<ItemData>();
    public List<ItemData>playerInventory = new List<ItemData>();
    public List<GameObject>playerInventoryUI = new List<GameObject>();
    public GameObject inventoryUI;
    public GameObject itemInventoryUI;
    public List<GameObject>prefabsConstructableItems = new List<GameObject>();
    public Transform itemParentForUI;
    public Toggle EnableRemove;
    public float money;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){
            if (!inventoryUI.active) inventoryUI.SetActive(true);
            else                     inventoryUI.SetActive(false);
        }
    }
    
    public void AddDrop(GameObject drop){

        ItemData newItemData = drop.GetComponent<Drop>().itemdata;

        bool constructable = false;
        GameObject constructableObjectUI = new GameObject();
        GameObject newItemUI;
        foreach(var construct in prefabsConstructableItems){
            if (construct.GetComponent<ConstructableItemUI>().item == newItemData){
                constructable = true;
                constructableObjectUI = construct;
                break;
            }
        }
            playerInventory.Add(newItemData);
            if (!constructable) {
                newItemUI = Instantiate(itemInventoryUI, new Vector2(0, 0), Quaternion.identity, itemParentForUI);
            }
            else{
                newItemUI = Instantiate(constructableObjectUI, new Vector2(0, 0), Quaternion.identity, itemParentForUI);
            }
            

            var itemName = newItemUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = newItemUI.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = newItemData.name;
            if (newItemData.sprite != null){
                itemIcon.sprite = newItemData.sprite;
            }
            // if (!constructable){
            newItemUI.GetComponent<ItemUI>().item = newItemData;
            newItemUI.GetComponent<ItemUI>().whereNow = "inventory";
            // }

            playerInventoryUI.Add(newItemUI);
        
        // EnableItemsRemove();
    }

    public void AddItem(GameObject item){
        ItemData newItemData = item.GetComponent<ItemUI>().item;
        
        bool constructable = false;
        GameObject constructableObjectUI = new GameObject();
        GameObject newItemUI;
        foreach(var construct in prefabsConstructableItems){
            if (construct.GetComponent<ConstructableItemUI>().item == newItemData){
                constructable = true;
                constructableObjectUI = construct;
                break;
            }
        }

        playerInventory.Add(newItemData);
        if (!constructable) {
            newItemUI = Instantiate(itemInventoryUI, new Vector2(0, 0), Quaternion.identity, itemParentForUI);
        }
        else{
            newItemUI = Instantiate(constructableObjectUI, new Vector2(0, 0), Quaternion.identity, itemParentForUI);
        }

        var itemName = newItemUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        var itemIcon = newItemUI.transform.Find("ItemIcon").GetComponent<Image>();

        itemName.text = newItemData.name;
        if (newItemData.sprite != null){
            itemIcon.sprite = newItemData.sprite;
        }
        newItemUI.GetComponent<ItemUI>().item = newItemData;
        newItemUI.GetComponent<ItemUI>().whereNow = "inventory";
        playerInventoryUI.Add(newItemUI);
        // EnableItemsRemove();
    }

    public void EnableItemsRemove(){
        if (EnableRemove.isOn){
            foreach(GameObject item in playerInventoryUI){
                item.transform.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        if (!EnableRemove.isOn){
            foreach(GameObject item in playerInventoryUI){
                Debug.Log("Whyy");
                item.transform.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
    public void RemoveItem(GameObject item){
        // Debug.Log("CALLING");
        if (playerInventoryUI.Contains(item)){
            // Debug.Log("CALLING2");
            // int index = playerInventoryUI.FindIndex(item);
            Destroy(item);
            playerInventoryUI.Remove(item);
            playerInventory.Remove(item.GetComponent<ItemUI>().item);
        }
    }

    public void AddMoney(float amount){
        money += amount;
    }
    public void RemoveMoney(float amount){
        money -= amount;
    }

    public void OpenInventory(){
        inventoryUI.SetActive(true);
    }
    public void CloseInventory(){
        inventoryUI.SetActive(false);
    }
}
