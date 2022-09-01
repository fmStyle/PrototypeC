using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerFunctions : MonoBehaviour
{

    HashSet<GameObject> objectsTouchingPlayer;
    PlayerFunctions playerFunctions;
    
    void Start()
    {
        objectsTouchingPlayer = new HashSet<GameObject>();
        playerFunctions = GetComponent<PlayerFunctions>();
    }

    void Update()
    {
        foreach (GameObject randomobject in objectsTouchingPlayer)
        {
            if (randomobject.tag == "boulder"){
                // If the player clicks when close to a boulder object it calls the Pick function to affect the boulder
                if (Input.GetMouseButtonDown(0)){
                    playerFunctions.Mine(randomobject);
                }
            }
            if (randomobject.tag == "drop"){
                if (Input.GetKeyDown(KeyCode.E)){
                    playerFunctions.PickupDrop(randomobject);
                    Destroy(randomobject);
                }
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        objectsTouchingPlayer.Add(collider.gameObject);
    }
    void OnTriggerExit2D(Collider2D collider){
        if (objectsTouchingPlayer.Contains(collider.gameObject)){
            objectsTouchingPlayer.Remove(collider.gameObject);
        }
    }
}
