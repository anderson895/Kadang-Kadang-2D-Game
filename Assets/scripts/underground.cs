using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underground : MonoBehaviour
{
    public GameObject player; // Reference to the player object

    // Start is called before the first frame update
    void Start()
    {
        // Ignore collision between the player's collider and the object's collider
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
