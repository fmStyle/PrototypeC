using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderData : MonoBehaviour
{
    float totalDurability;
    public float durability;
    public float necessaryStrength;
    public int rarity;
    public GameObject drop;
    public GameObject player;
    public Sprite State1;
    public Sprite State2;
    public Sprite State3;
    SpriteRenderer spriteRenderer;
    PlayerData playerData;
    void Start(){
        playerData = player.GetComponent<PlayerData>();
        player = GameObject.FindGameObjectWithTag("player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        totalDurability = durability;
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
        if ((durability*100/totalDurability > 33) && (durability*100/totalDurability < 66) && (spriteRenderer.sprite == State1)){
            spriteRenderer.sprite = State2;
        }
        if ((durability*100/totalDurability < 33) && (spriteRenderer.sprite == State2)){
            spriteRenderer.sprite = State3;
        }
    }

}
