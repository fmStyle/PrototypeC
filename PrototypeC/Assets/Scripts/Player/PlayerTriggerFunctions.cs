using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI actionInfo;

    public GameObject SignUI;
    bool firstTimeSign;
    PlayerInventory playerInventory;
    PlayerData playerData;
    PlayerMovement playerMovement;
    public BedScript bedScript;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindWithTag("audiomanager").GetComponent<AudioManager>();
        firstTimeSign = false;
        objectsTouchingPlayer = new HashSet<GameObject>();
        playerFunctions = GetComponent<PlayerFunctions>();
        playerInventory = GetComponent<PlayerInventory>();
        playerData = GetComponent<PlayerData>();
        playerMovement = GetComponent<PlayerMovement>();
        actionInfo.text = "";
    }

    void Update()
    {
        if (objectsTouchingPlayer.Count == 0){
            actionInfo.text = "";
        }
        foreach (GameObject randomobject in objectsTouchingPlayer)
        {
            /// Normal Interactions
            if (randomobject.tag == "boulder"){
                // If the player clicks when close to a boulder object it calls the Pick function to affect the boulder
                if (Input.GetMouseButtonDown(0)){
                    playerFunctions.Mine(randomobject);
                    break;
                }
                if (playerData.strengthLevel >= randomobject.GetComponent<BoulderData>().necessaryStrength){
                    actionInfo.text = "Left Click) Mine Boulder";
                } else{
                    actionInfo.text = "Left Click) Not enough strenght level (Necessary " + randomobject.GetComponent<BoulderData>().necessaryStrength.ToString() + ")";
                }
                
            }
            if (randomobject.tag == "drop"){
                if (Input.GetKeyDown(KeyCode.E)){
                    playerFunctions.PickupDrop(randomobject);
                    if (randomobject != null) Destroy(randomobject);
                    break;
                }
                actionInfo.text = "E) Collect " + randomobject.GetComponent<Drop>().itemdata.name;
            }
            if (randomobject.tag == "minecart"){
                if (Input.GetKeyDown(KeyCode.E)){
                    audioManager.Play("Use1");
                    minecartInventory.SetActive(true);
                    playerInventory.OpenInventory();
                    break;
                }
                actionInfo.text = "E) Open minecart inventory";
            }
            if (randomobject.tag == "bed"){
                actionInfo.text = "E) Sleep";
                if (Input.GetKeyDown(KeyCode.E) || playerMovement.actionHappening){
                    bedScript.Sleep();
                    actionInfo.text = "";
                    break;
                }
                
            }
            if (randomobject.tag == "plantplot"){
                if (Input.GetKeyDown(KeyCode.E) && randomobject.GetComponent<Plantplot>().Harvestable()){
                    randomobject.GetComponent<Plantplot>().Harvest();
                    audioManager.Play("Use3");
                    break;
                }
                if (Input.GetKeyDown(KeyCode.E) && !randomobject.GetComponent<Plantplot>().Harvestable()){
                    randomobject.GetComponent<Plantplot>().OpenPlantPlotMenu();
                    playerInventory.OpenInventory();
                    audioManager.Play("Use2");
                }
                actionInfo.text = "E) Open plantpot inventory";
            }

            /// Master
            if (randomobject.tag == "enterhousemaster"){
                if (Input.GetKeyDown(KeyCode.E)){
                    transform.position = new Vector3(MasterHousePosition.position.x, MasterHousePosition.position.y, 0);
                    audioManager.Play("Use3");
                }
                actionInfo.text = "E) Enter house of an old friend";
            }
            if (randomobject.tag == "exithousemaster"){
                if (Input.GetKeyDown(KeyCode.E)){
                    transform.position = new Vector3(MasterHouseExitPosition.position.x, MasterHouseExitPosition.position.y, 0);
                    audioManager.Play("Use3");
                }
                actionInfo.text = "E) Exit house";
                
            }
            if (randomobject.tag == "masternpc"){
                actionInfo.text = "E) Open Ability Shop\nC) Start Dialog";
                Dialogue dialogue = randomobject.GetComponent<Dialogue>();
                
                if (dialogue.IsDialogActive()){
                    actionInfo.text = "C) Skip";
                }
                if (Input.GetKeyDown(KeyCode.E)){
                    if (SkillShop.activeSelf){
                        SkillShop.SetActive(false);
                    }
                    else if (!SkillShop.activeSelf && !dialogue.IsDialogActive()){
                        SkillShop.SetActive(true);
                        audioManager.Play("Use2");
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
                    audioManager.Play("Use3");
                }
                actionInfo.text = "E) Enter house of the botanist";
                
            }
            if (randomobject.tag == "exithousebotanist"){
                if (Input.GetKeyDown(KeyCode.E)){
                    transform.position = new Vector3(BotanistExitPosition.position.x, BotanistExitPosition.position.y, 0);
                    audioManager.Play("Use3");
                }
                actionInfo.text = "E) Exit house";
                
            }
            if (randomobject.tag == "botanistnpc"){
                actionInfo.text = "E) Open Shop\nC) Start Dialog";
                Dialogue dialogue = randomobject.GetComponent<Dialogue>();
                if (dialogue.IsDialogActive()){
                    actionInfo.text = "C) Skip";
                }
                if (Input.GetKeyDown(KeyCode.E)){
                    if (BotanistShop.activeSelf){
                        BotanistShop.SetActive(false);
                    }
                    else if (!SkillShop.activeSelf && !dialogue.IsDialogActive()){
                        BotanistShop.SetActive(true);
                        playerInventory.OpenInventory();
                        audioManager.Play("Use3");
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
            if (randomobject.tag == "sign"){
                if (Input.GetKeyDown(KeyCode.E)){
                    if (!SignUI.activeSelf){
                        SignUI.SetActive(true);
                        audioManager.Play("Use3");
                    } 
                    else{
                        if (!firstTimeSign){
                            Destroy(randomobject.transform.Find("ExclamationSign").gameObject);
                            firstTimeSign = true;
                        }
                        SignUI.SetActive(false);
                    }
                }
                actionInfo.text = "E) Read Sign (Seems important)";
            }

            if (randomobject.tag == "radio"){

                if (randomobject.GetComponent<Radio>().IsTurnedOn()){
                    actionInfo.text = "E) Turn off radio";
                    if (Input.GetKeyDown(KeyCode.E)){
                        randomobject.GetComponent<Radio>().TurnOffRadio();
                    }
                    
                } else{
                    actionInfo.text = "E) Turn On Radio";
                    if (Input.GetKeyDown(KeyCode.E)){
                        randomobject.GetComponent<Radio>().TurnOnRadio();
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
        if (collider.tag == "sign"){
            if (!firstTimeSign){
                Destroy(collider.transform.Find("ExclamationSign").gameObject);
                firstTimeSign = true;
            }
            SignUI.SetActive(false);
        }
    }
}
