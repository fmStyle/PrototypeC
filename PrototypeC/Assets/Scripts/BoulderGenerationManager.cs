using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range{
    public range(int a, int b){
        this.a = a;
        this.b = b;
    }
    public int a;
    public int b;
}

public class BoulderGenerationManager : MonoBehaviour
{
    public List<GameObject>GenerableBoulders = new List<GameObject>();
    List<range>Ranges = new List<range>();
    int totalPossibilities = 0;
    void Start()
    {
        for (int i = 0; i<GenerableBoulders.Count; ++i){
            Ranges.Add(new range(totalPossibilities, totalPossibilities + GenerableBoulders[i].GetComponent<BoulderData>().rarity));
            totalPossibilities += GenerableBoulders[i].GetComponent<BoulderData>().rarity;
            
        }
        for (int i = 0; i<100; ++i){
            int randomValue = Random.Range(0, totalPossibilities);
            for (int j = 0; j<Ranges.Count; ++j){
                if (randomValue >= Ranges[j].a && randomValue < Ranges[j].b){
                    GameObject newBoulder = Instantiate(GenerableBoulders[j], new Vector2(Random.Range(6, 70), Random.Range(-6, -70)), Quaternion.identity);
                    newBoulder.transform.parent = gameObject.transform;
                    break;
                }
            }
        }
    }


}
