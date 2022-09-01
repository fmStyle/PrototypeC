using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector2 velocity;

    public float acceleration;
    public float maxVelocity;
    public float friction;
    public float desacceleration;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)){
            velocity.x -= acceleration;
        }
        if (Input.GetKey(KeyCode.D)){
            velocity.x += acceleration;
        }
        if (Input.GetKey(KeyCode.W)){
            velocity.y += acceleration;
        }
        if (Input.GetKey(KeyCode.S)){
            velocity.y -= acceleration;
        }
        if (velocity.magnitude < friction){
            velocity.x = 0.0f;
            velocity.y = 0.0f;
        }
        if (velocity.magnitude > maxVelocity){
            velocity.x = velocity.normalized.x * maxVelocity;
            velocity.y = velocity.normalized.y * maxVelocity;
        }
        velocity *= desacceleration;
        rigidbody.velocity = velocity;
    }
}
