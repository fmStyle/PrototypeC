using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public ItemData itemdata;
    Rigidbody2D rigidbody;
    public float initialVelocity;
    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (itemdata.sprite != null){
            GetComponent<SpriteRenderer>().sprite = itemdata.sprite;
        }
        float randomAngle = Random.Range(0, Mathf.PI*2);
        velocity.x = Mathf.Cos(randomAngle);
        velocity.y = Mathf.Sin(randomAngle);
        velocity *= initialVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity *= 0.95f;
        rigidbody.velocity = velocity;
    }
}
