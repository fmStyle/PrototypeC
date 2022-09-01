using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector2 velocity;
    PlayerData playerData;

    public float acceleration;
    public float maxVelocity;
    public float friction;
    public float desacceleration;
    public float velocityLevelScaling;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
}
