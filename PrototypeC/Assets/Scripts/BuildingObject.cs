using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingObject : MonoBehaviour
{
    // BoxCollider2D boxcollider;

    // Each building object should have a Box Collider and a Polygon Collider, one for managing the trigger and events, and the other to
    // Manage the collisions with the player.
    BoxCollider2D boxcollider;
    PolygonCollider2D polygoncollider;
    HashSet<GameObject> objectsTouchingBuildingObject;
    // Color32 originalColor;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        polygoncollider = GetComponent<PolygonCollider2D>();
        polygoncollider.enabled = false;
        objectsTouchingBuildingObject = new HashSet<GameObject>();
        int LayerBuilding = LayerMask.NameToLayer("Building Object");
        gameObject.layer = LayerBuilding;
        // originalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsObstructing()){
            GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 150);
        } else{
            GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 150);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        objectsTouchingBuildingObject.Add(collider.gameObject);
    }
    void OnTriggerExit2D(Collider2D collider){
        if (objectsTouchingBuildingObject.Contains(collider.gameObject)){
            objectsTouchingBuildingObject.Remove(collider.gameObject);
        }
    }
    public bool IsObstructing(){
        if (objectsTouchingBuildingObject.Count > 0) return true;
        return false;
    }
    public void FinishedBuilding(){
        polygoncollider.enabled = true;
        int LayerDefault = LayerMask.NameToLayer("Default");
        gameObject.layer = LayerDefault;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        Destroy(this);
    }
}
