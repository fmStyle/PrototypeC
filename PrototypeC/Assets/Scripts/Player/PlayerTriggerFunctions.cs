using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerFunctions : MonoBehaviour
{

    HashSet<GameObject> objectsTouchingPlayer;
    PlayerFunctions playerFunctions;
    public GameObject minecartInventory;
    public GameObject SkillShop;
    public Transform MasterHousePosition;
    public Transform MasterHouseExitPosition;

    public GameObject BotanistShop;
    public Transform BotanistHousePosition;
    public Transform BotanistExitPosition;

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
            /// Normal Interactions
            if (randomobject.tag == "boulder"){
                // If the player clicks when close to a boulder object it calls the Pick function to affect the boulder
                if (Input.GetMouseButtonDown(0)){
                    playerFunctions.Mine(randomobject);
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

            /// Master
            if (randomobject.tag == "enterhousemaster"){
                if (Input.GetKeyDown(KeyCode.E)){
                    transform.position = new Vector3(MasterHousePosition.position.x, MasterHousePosition.position.y, 0);
                    
                }
                
            }
            if (randomobject.tag == "exithousemaster"){
                if (Input.GetKeyDown(KeyCode.E)){
                    transform.position = new Vector3(MasterHouseExitPosition.position.x, MasterHouseExitPosition.position.y, 0);
                }
                
            }
            if (randomobject.tag == "masternpc"){
                Dialogue dialogue = randomobject.GetComponent<Dialogue>();
                if (Input.GetKeyDown(KeyCode.E)){
                    if (SkillShop.activeSelf){
                        SkillShop.SetActive(false);
                    }
                    else if (!SkillShop.activeSelf && !dialogue.IsDialogActive()){
                        SkillShop.SetActive(true);
                    }
                }
                if (Input.GetKeyDown(KeyCode.C)){
                    if (!dialogue.ConversationStarted() && !SkillShop.activeSelf){
                        playerMovement.EnterActionHappening();
                        dialogue.StartDialogue();
                    }
                    else if (dialogue.ConversationStarted() && !dialogue.LineEnded()){
                        dialogue.EndLine();
                    }
                    else if (dialogue.ConversationStarted() && dialogue.LineEnded()){
                        if(dialogue.NextDialogueLine()) {
                            playerMovement.ExitActionHappening();
                        }
                    }
                }
            }


            /// Botanist
            if (randomobject.tag == "enterhousebotanist"){
                if (Input.GetKeyDown(KeyCode.E)){
                    transform.position = new Vector3(BotanistHousePosition.position.x, BotanistHousePosition.position.y, 0);
                    
                }
                
            }
            if (randomobject.tag == "exithousebotanist"){
                if (Input.GetKeyDown(KeyCode.E)){
                    transform.position = new Vector3(BotanistExitPosition.position.x, BotanistExitPosition.position.y, 0);
                }
                
            }
            if (randomobject.tag == "botanistnpc"){
                Dialogue dialogue = randomobject.GetComponent<Dialogue>();
                if (Input.GetKeyDown(KeyCode.E)){
                    if (BotanistShop.activeSelf){
                        BotanistShop.SetActive(false);
                    }
                    else if (!SkillShop.activeSelf && !dialogue.IsDialogActive()){
                        BotanistShop.SetActive(true);
                    }
                }
                if (Input.GetKeyDown(KeyCode.C)){
                    if (!dialogue.ConversationStarted() && !BotanistShop.activeSelf){
                        playerMovement.EnterActionHappening();
                        dialogue.StartDialogue();
                    }
                    else if (dialogue.ConversationStarted() && !dialogue.LineEnded()){
                        dialogue.EndLine();
                    }
                    else if (dialogue.ConversationStarted() && dialogue.LineEnded()){
                        if(dialogue.NextDialogueLine()) {
                            playerMovement.ExitActionHappening();
                        }
                    }
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
        if (collider.tag == "masternpc"){
            SkillShop.SetActive(false);
        }
        if (collider.tag == "botanistnpc"){
            BotanistShop.SetActive(false);
        }
    }
}
