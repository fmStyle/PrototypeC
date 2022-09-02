using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderData : MonoBehaviour
{
    public float durability;
    public float necessaryStrength;
    public int rarity;
    public GameObject drop;
    public GameObject player;
    PlayerData playerData;
    void Start(){
        playerData = player.GetComponent<PlayerData>();
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        if (durability <= 0){
            int numberOfDrops = Random.Range(1, 3 + playerData.luckLevel);
            for (int i = 0; i<numberOfDrops; ++i){
                Instantiate(drop, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
