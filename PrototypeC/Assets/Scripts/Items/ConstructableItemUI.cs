using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructableItemUI : ItemUI
{

    public GameObject constructableGameObject;
    public Camera mainCamera;
    public override void action(){
        
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Vector3 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0f;
        GameObject newObj = Instantiate(constructableGameObject, newPos, Quaternion.identity);
        // newObj.GetComponent<BoxCollider2D>().
        newObj.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 150);
        newObj.AddComponent<BuildingObject>();
        player.GetComponent<PlayerMovement>().EnterBuildingMode(newObj, gameObject);
    }
}
