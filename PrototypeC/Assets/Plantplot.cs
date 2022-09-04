using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Plantplot : MonoBehaviour
{
    GameObject seed;
    private bool dragDestroyed;
    public GameObject plantPlotMenu;
    GameObject newPlantPlotMenu;
    GameObject drop;
    Transform parentForSeed;
    PlantpotManager plantpotManager;
    public float harvestingTime;
    bool harvestable;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        dragDestroyed = false;
        plantpotManager = GameObject.FindWithTag("plantplot manager").GetComponent<PlantpotManager>();
        newPlantPlotMenu = Instantiate(plantPlotMenu, plantPlotMenu.transform.position, Quaternion.identity);
        newPlantPlotMenu.transform.parent = GameObject.FindWithTag("canvas").transform;
        newPlantPlotMenu.GetComponent<RectTransform>().anchoredPosition = new Vector3(300, 0, 0);
        newPlantPlotMenu.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        newPlantPlotMenu.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newPlantPlotMenu.GetComponent<OnDropManagerPlantplot>().plantplot = gameObject;
        newPlantPlotMenu.GetComponent<OnDropManagerPlantplot>().player = GameObject.FindWithTag("player");
        parentForSeed = newPlantPlotMenu.transform.Find("Container").transform;
        ClosePlantPlotMenu();
        // newPlantPlotMenu.transform.position = new Vector3(300, 0, 0);
    }

    void Update(){
        if (AlreadyHasSeed() && !dragDestroyed) {
            Destroy(seed.GetComponent<DragAndDrop>());
            dragDestroyed = true;
        }
    }

    // Update is called once per frame
    public void AddSeed(GameObject itemUI){
        if (AlreadyHasSeed()) return;
        seed = itemUI;
        
        int itemID = itemUI.GetComponent<ItemUI>().item.id;
        SeedData seedData = plantpotManager.GetSeedDataWithID(itemID);
        drop = plantpotManager.GetDropWithID(itemID);
        Seed childSeed = transform.Find("Seed").GetComponent<Seed>();
        childSeed.plantedSeed = seedData;
        childSeed.StartState();
        
        plantpotManager.AddSeed(childSeed);

    }

    public bool AlreadyHasSeed(){
        if (seed == null) return false;
        else              return true;
    }

    public void OpenPlantPlotMenu(){
        newPlantPlotMenu.SetActive(true);
    }
    public void ClosePlantPlotMenu(){
        newPlantPlotMenu.SetActive(false);
    }
    public bool Harvestable(){
        if (transform.Find("Seed").GetComponent<Seed>().ActualState() == 3){
            return true;
        } else{
            return false;
        }
    }
    public void Harvest(){
        for (int i=2; i<Random.Range(3, 5); ++i){
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        transform.Find("Seed").GetComponent<Seed>().Harvest();
        if (seed != null) Destroy(seed);
    }
}
