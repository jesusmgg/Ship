using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public float gravity;

    Vector2 velocity;

    Collider2D collider;

    void Start()
    {
        velocity = Vector2.zero;

        collider = GetComponent<Collider2D>();
    }
    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        Vector2 newPosition = transform.position;
        
        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        
        // Clamp velocity
        Mathf.Clamp(velocity.x, -speed, speed);
        Mathf.Clamp(velocity.y, -speed, speed);
        
        // Set new position
        newPosition += velocity;
        transform.position = newPosition;
    }

    bool CheckCollision(Vector2 position)
    {
        if (collider.bounds.Intersects())
        
        return true;
    }
}