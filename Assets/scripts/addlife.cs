using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addlife : MonoBehaviour
{
    public float attack1Damage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            healthbarscript.health += attack1Damage;
            //ScoreScript.curscore+=15;
        }
    }

}
