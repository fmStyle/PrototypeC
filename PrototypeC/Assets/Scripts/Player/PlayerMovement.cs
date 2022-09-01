using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector2 velocity;
    PlayerData playerData;
    private GameObject miningBoulder;

    public float acceleration;
    public float maxVelocity;
    public float friction;
    public float desacceleration;
    public float velocityLevelScaling;
    public float miningSpeed = 1.0f;
    private float miningTimer;
    private bool mining;
    bool actionHappening;
    

    // Start is called before the first frame update
    void Start()
    {
        miningTimer = 0.0f;
        actionHappening = false;
        rigidbody = GetComponent<Rigidbody2D>();
        playerData = GetComponent<PlayerData>();
    }

    void Update(){
        /// The health of the boulder gets reduced the last tick
        if(CheckMining()){
            BoulderData boulderData = miningBoulder.GetComponent<BoulderData>();
            boulderData.durability -= playerData.pickaxeAbilityLevel * 20.0f;
        }
    }
    void FixedUpdate()
    {

        
        if (!actionHappening && !mining){
            if (Input.GetKey(KeyCode.A)){
                velocity.x -= acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
            if (Input.GetKey(KeyCode.D)){
                velocity.x += acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
            if (Input.GetKey(KeyCode.W)){
                velocity.y += acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
            if (Input.GetKey(KeyCode.S)){
                velocity.y -= acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
        }
        if (velocity.magnitude < friction){
            velocity.x = 0.0f;
            velocity.y = 0.0f;
        }
        if (velocity.magnitude > (maxVelocity + (playerData.velocityLevel * velocityLevelScaling))){
            velocity.x = velocity.normalized.x * (maxVelocity + (playerData.velocityLevel * velocityLevelScaling));
            velocity.y = velocity.normalized.y * (maxVelocity + (playerData.velocityLevel * velocityLevelScaling));
        }
        velocity *= desacceleration;
        rigidbody.velocity = velocity;
    }
    public void Mine(GameObject boulder){
        if (mining == true) return;
        mining = true;
        miningTimer = 1.0f;
        miningBoulder = boulder;
    }
    /// Returns true when finished the timer
    public bool CheckMining(){
        if (mining){
            miningTimer -= Time.deltaTime;
            if (miningTimer <= 0.0f){
                mining = false;
                miningTimer = 1.0f;

                return true;
            }
        }
        return false;
    }
}
