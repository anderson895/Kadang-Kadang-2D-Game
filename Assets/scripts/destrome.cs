using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrome : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ScoreScript.curscore += 1;
            Destroy(gameObject); // Remove the delay here
        }
    }
}
