using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objecLeftRight : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust the movement speed as desired
    private bool movingRight = false; // Set the initial movement direction to left

    private void Start()
    {
        // Set the initial movement direction to left
        movingRight = false;
    }

    private void Update()
    {
        // Move the object left or right
        if (movingRight)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger collided with any object tagged as "wall"
        if (other.CompareTag("wall"))
        {
            // Change the movement direction
            movingRight = !movingRight;
        }
    }
}
