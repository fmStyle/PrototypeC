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
    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            velocity.x -= acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)){
            velocity.x += acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W)){
            velocity.y += acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)){
            velocity.y -= acceleration * Time.deltaTime;
        }
        if (velocity.magnitude < friction){
            velocity.x = 0.0f;
            velocity.y = 0.0f;
        }
        if (velocity.magnitude > maxVelocity){
            velocity.x = velocity.normalized.x * maxVelocity * Time.deltaTime;
            velocity.y = velocity.normalized.y * maxVelocity * Time.deltaTime;
        }
        velocity *= desacceleration;
        rigidbody.velocity = velocity;
    }
}
