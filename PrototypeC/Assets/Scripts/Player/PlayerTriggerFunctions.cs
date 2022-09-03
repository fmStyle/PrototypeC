using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerFunctions : MonoBehaviour
{

    HashSet<GameObject> objectsTouchingPlayer;
    PlayerFunctions playerFunctions;
    public GameObject minecartInventory;
    PlayerInventory playerInventory;
    PlayerData playerData;
    PlayerMovement playerMovement;
    public BedScript bedScript;

    void Start()
    {
        objectsTouchingPlayer = new HashSet<GameObject>();
        playerFunctions = GetComponent<PlayerFunctions>();
        playerInventory = GetComponent<PlayerInventory>();
        playerData = GetComponent<PlayerData>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        foreach (GameObject randomobject in objectsTouchingPlayer)
        {
            if (randomobject.tag == "boulder"){
                // If the player clicks when close to a boulder object it calls the Pick function to affect the boulder
                if (Input.GetMouseButtonDown(0)){
                    playerFunctions.Mine(randomobject);
                    // playerData.energy -= 1;
                    break;
                }
            }
            if (randomobject.tag == "drop"){
                if (Input.GetKeyDown(KeyCode.E)){
                    playerFunctions.PickupDrop(randomobject);
                    if (randomobject != null) Destroy(randomobject);
                    break;
                }
            }
            if (randomobject.tag == "minecart"){
                if (Input.GetKeyDown(KeyCode.E)){
                    minecartInventory.SetActive(true);
                    playerInventory.OpenInventory();
                    break;
                }
            }
            if (randomobject.tag == "bed"){
                if (Input.GetKeyDown(KeyCode.E) || playerMovement.actionHappening){
                    bedScript.Sleep();
                    break;
                }
            }
            if (randomobject.tag == "plantplot"){
                if (Input.GetKeyDown(KeyCode.E) && randomobject.GetComponent<Plantplot>().Harvestable()){
                    randomobject.GetComponent<Plantplot>().Harvest();
                    break;
                }
                if (Input.GetKeyDown(KeyCode.E) && !randomobject.GetComponent<Plantplot>().Harvestable()){
                    randomobject.GetComponent<Plantplot>().OpenPlantPlotMenu();
                    playerInventory.OpenInventory();
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
        if (collider.tag == "minecart"){
            minecartInventory.SetActive(false);
            playerInventory.CloseInventory();
        }
        if (collider.tag == "plantplot"){
            collider.GetComponent<Plantplot>().ClosePlantPlotMenu();
            playerInventory.CloseInventory();
        }
    }
}
