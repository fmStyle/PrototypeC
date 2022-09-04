using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinecartInventory : MonoBehaviour
{
    public List<ItemData>minecartInventory = new List<ItemData>();
    public List<GameObject>minecartInventoryUI = new List<GameObject>();
    public GameObject inventoryUI;
    public GameObject itemInventoryUI;
    public Transform itemParentForUI;
    public GameObject earningsText;

    void Start(){
        earningsText.GetComponent<TextMeshProUGUI>().text = "Earnings: 0";
    }
    public void AddItem(GameObject item){
        ItemData newItemData = item.GetComponent<ItemUI>().item;
        // item.GetCommponent<ItemUI>().whereNow = "minecart";
        minecartInventory.Add(newItemData);
        item.transform.parent = itemParentForUI.transform;
        // minecartInventoryUI.Add(item);
        GameObject newItemUI = Instantiate(itemInventoryUI, new Vector2(0, 0), Quaternion.identity, itemParentForUI);
        var itemName = newItemUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        var itemIcon = newItemUI.transform.Find("ItemIcon").GetComponent<Image>();

        itemName.text = newItemData.name;
        if (newItemData.sprite != null){
            itemIcon.sprite = newItemData.sprite;
        }
        newItemUI.GetComponent<ItemUI>().item = newItemData;
        newItemUI.GetComponent<ItemUI>().whereNow = "minecart";
        minecartInventoryUI.Add(newItemUI);
        earningsText.GetComponent<TextMeshProUGUI>().text = "Earnings: " + this.Earnings().ToString();

        // EnableItemsRemove();
    }

    public void RemoveItem(GameObject item){
        Debug.Log("CALLING");
        if (minecartInventoryUI.Contains(item)){
            Debug.Log("CALLING2");
            // int index = playerInventoryUI.FindIndex(item);
            Destroy(item);
            minecartInventoryUI.Remove(item);
            minecartInventory.Remove(item.GetComponent<ItemUI>().item);
        }
        earningsText.GetComponent<TextMeshProUGUI>().text = "Earnings: " + this.Earnings().ToString();
    }
    public float Earnings(){
        float earnings = 0;
        foreach (ItemData item in minecartInventory){
            earnings += item.cost;
        }
        return earnings;
    }

    public void CleanInventoryAndPayPlayer(GameObject player){
        player.GetComponent<PlayerInventory>().AddMoney(this.Earnings());
        foreach (GameObject item in minecartInventoryUI){
            Destroy(item);
        }
        minecartInventoryUI.Clear();
        minecartInventory.Clear();
        player.GetComponent<PlayerData>().UpdateStrings();
    }
}