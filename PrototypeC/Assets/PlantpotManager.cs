using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantpotManager : MonoBehaviour
{
    public List<SeedData>ListOfPossibleSeeds = new List<SeedData>();
    public List<GameObject>ListOfPossibleDrops = new List<GameObject>();
    List<Seed>seeds = new List<Seed>();
    public void AddSeed(Seed seed){
        seeds.Add(seed);
    }
    public void NextStateOnEverySeed(){
        foreach(var seed in seeds){
            if (seed.isPlanted() && seed.ActualState()<3){
                seed.NextState();
            }
        }
    }
    public bool isIdContained(int id){
        foreach(var possibleSeed in ListOfPossibleSeeds){
            if (id == possibleSeed.id){
                return true;
            }
        }
        return false;
    }
    public SeedData GetSeedDataWithID(int id){
        foreach(var possibleSeed in ListOfPossibleSeeds){
            if (id == possibleSeed.id){
                return possibleSeed;
            }
        }
        return null;
    }
    public GameObject GetDropWithID(int id){
        foreach (var drop in ListOfPossibleDrops){
            if (id == drop.GetComponent<Drop>().itemdata.id){
                return drop;
            }
        }
        return null;
    }
}
