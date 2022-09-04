using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public int level;
    public int strengthLevel;
    public int velocityLevel;
    public int botanistLevel;
    public int pickaxeAbilityLevel;
    public int luckLevel;
    
    public int maxEnergy;
    public int energy;
    PlayerInventory playerInventory;
    public GameObject Stats;
    public GameObject SkillShop;
    // public AudioManager audioManager;

    TextMeshProUGUI moneyText;
    TextMeshProUGUI strenghtLevelText;
    TextMeshProUGUI botanistLevelText;
    TextMeshProUGUI pickaxeLevelText;
    TextMeshProUGUI luckLevelText;

    TextMeshProUGUI strenghtLevelUpText;
    TextMeshProUGUI botanistLevelUpText;
    TextMeshProUGUI pickaxeLevelUpText;
    TextMeshProUGUI luckLevelUpText;

    public float strenghtLevelUpPrice = 75f;
    public float botanistLevelUpPrice = 200f;
    public float pickaxeLevelUpPrice = 150f;
    public float luckLevelUpPrice = 500f;
    void Start()
    {
        // audioManager = GetComponent<PlayerMovement>().audioManager;
        level = 1;
        strengthLevel = 1;
        velocityLevel = 1;
        botanistLevel = 1;
        pickaxeAbilityLevel = 1;
        luckLevel = 1;
        maxEnergy = 30;
        energy = maxEnergy;
        playerInventory = GetComponent<PlayerInventory>();

        moneyText = Stats.transform.Find("Money").GetComponent<TextMeshProUGUI>();
        strenghtLevelText = Stats.transform.Find("Strenght").GetComponent<TextMeshProUGUI>();
        botanistLevelText = Stats.transform.Find("Botanist").GetComponent<TextMeshProUGUI>();
        pickaxeLevelText = Stats.transform.Find("Pickaxe").GetComponent<TextMeshProUGUI>();
        luckLevelText = Stats.transform.Find("Luck").GetComponent<TextMeshProUGUI>();

        strenghtLevelUpText = SkillShop.transform.Find("Strenght").transform.Find("LevelUpButton").transform.Find("Price").GetComponent<TextMeshProUGUI>();
        botanistLevelUpText = SkillShop.transform.Find("Botanist").transform.Find("LevelUpButton").transform.Find("Price").GetComponent<TextMeshProUGUI>();
        pickaxeLevelUpText = SkillShop.transform.Find("Pickaxe").transform.Find("LevelUpButton").transform.Find("Price").GetComponent<TextMeshProUGUI>();
        luckLevelUpText = SkillShop.transform.Find("Luck").transform.Find("LevelUpButton").transform.Find("Price").GetComponent<TextMeshProUGUI>();
        UpdateStrings();
    }

    // Update is called once per frame
    void Update()
    {
        // moneyText.text = "Money: " + playerInventory.money.ToString();
        // strenghtLevelText.text = "Strenght: " + strengthLevel.ToString();
        // botanistLevelText.text = "Botanist Level: " + botanistLevel.ToString();
        // pickaxeLevelText.text = "Pickaxe Level: " + pickaxeAbilityLevel.ToString();
        // luckLevelText.text = "Luck Level: " + luckLevel.ToString();
    }

    public void UpdateStrings(){
        moneyText.text = "Money: " + playerInventory.Money().ToString();
        strenghtLevelText.text = "Strenght: " + strengthLevel.ToString();
        botanistLevelText.text = "Botanist Level: " + botanistLevel.ToString();
        pickaxeLevelText.text = "Pickaxe Level: " + pickaxeAbilityLevel.ToString();
        luckLevelText.text = "Luck Level: " + luckLevel.ToString();

        strenghtLevelUpText.text = "$" + strenghtLevelUpPrice.ToString();
        botanistLevelUpText.text = "$" + botanistLevelUpPrice.ToString();
        pickaxeLevelUpText.text = "$" + pickaxeLevelUpPrice.ToString();
        luckLevelUpText.text = "$" + luckLevelUpPrice.ToString();
    }
    

    /// Warning, these functions are made to be used on the OnClick() functions of the buttons
    public void LevelUpStrenght(){
        GameObject player = GameObject.FindWithTag("player");
        PlayerData playerDataAux = player.GetComponent<PlayerData>();
        PlayerInventory playerInventoryAux = player.GetComponent<PlayerInventory>();
        
        if (playerInventoryAux.GetComponent<PlayerInventory>().money >= playerDataAux.strenghtLevelUpPrice){
            playerDataAux.strengthLevel++;
            playerInventoryAux.RemoveMoney(playerDataAux.strenghtLevelUpPrice);
            playerDataAux.strenghtLevelUpPrice += playerDataAux.strenghtLevelUpPrice/4.0f;
        }
        playerDataAux.UpdateStrings();
        GameObject.FindWithTag("audiomanager").GetComponent<AudioManager>().Play("LevelUp");
    }
    public void LevelUpBotanist(){
        GameObject player = GameObject.FindWithTag("player");
        PlayerData playerDataAux = player.GetComponent<PlayerData>();
        PlayerInventory playerInventoryAux = player.GetComponent<PlayerInventory>();
        
        if (playerInventoryAux.GetComponent<PlayerInventory>().money >= playerDataAux.botanistLevelUpPrice){
            playerDataAux.botanistLevel++;
            playerInventoryAux.RemoveMoney(playerDataAux.botanistLevelUpPrice);
            playerDataAux.botanistLevelUpPrice += playerDataAux.botanistLevelUpPrice/4.0f;
        }
        playerDataAux.UpdateStrings();
        GameObject.FindWithTag("audiomanager").GetComponent<AudioManager>().Play("LevelUp");
    }
    public void LevelUpPickaxe(){
        GameObject player = GameObject.FindWithTag("player");
        PlayerData playerDataAux = player.GetComponent<PlayerData>();
        PlayerInventory playerInventoryAux = player.GetComponent<PlayerInventory>();
        
        if (playerInventoryAux.GetComponent<PlayerInventory>().money >= playerDataAux.pickaxeLevelUpPrice){
            playerDataAux.pickaxeAbilityLevel++;
            playerInventoryAux.RemoveMoney(playerDataAux.pickaxeLevelUpPrice);
            playerDataAux.pickaxeLevelUpPrice += playerDataAux.pickaxeLevelUpPrice/4.0f;
        }
        playerDataAux.UpdateStrings();
        player.GetComponent<PlayerMovement>().CalculateMiningSpeed();
        GameObject.FindWithTag("audiomanager").GetComponent<AudioManager>().Play("LevelUp");
    }
    public void LevelUpLuck(){
        GameObject player = GameObject.FindWithTag("player");
        PlayerData playerDataAux = player.GetComponent<PlayerData>();
        PlayerInventory playerInventoryAux = player.GetComponent<PlayerInventory>();
        
        if (playerInventoryAux.GetComponent<PlayerInventory>().money >= playerDataAux.luckLevelUpPrice){
            playerDataAux.luckLevel++;
            playerInventoryAux.RemoveMoney(playerDataAux.luckLevelUpPrice);
            playerDataAux.luckLevelUpPrice += playerDataAux.luckLevelUpPrice/4.0f;
        }
        playerDataAux.UpdateStrings();
        GameObject.FindWithTag("audiomanager").GetComponent<AudioManager>().Play("LevelUp");
    }
}
