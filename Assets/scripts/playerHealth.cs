using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class playerHealth : MonoBehaviour
{
    public float playerMaxHealth;
    public float pcurrentHealth;
    float edamage;
    private Animator anim;
    private playerController1 controller; // Reference to playerController1 component
    private Rigidbody2D rigidbody2D; // Reference to Rigidbody2D component

    // Use this for initialization
    void Start()
    {
        pcurrentHealth = playerMaxHealth;
        anim = GetComponent<Animator>();
        controller = GetComponent<playerController1>(); // Get reference to playerController1 component
        rigidbody2D = GetComponent<Rigidbody2D>(); // Get reference to Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            enemyAttack attackdamage = col.gameObject.GetComponent<enemyAttack>();
            edamage = attackdamage.attack1Damage;
            pcurrentHealth -= edamage;
            Debug.Log(edamage);
            if (pcurrentHealth <= 0)
            {
                anim.SetTrigger("Die");
                DisableMovement();
                Invoke("makeDeadWithDelay", 1f); // Invoke makeDeadWithDelay after 1 second
            }
        }

        if (col.tag == "heartHealth")
        {
            
            pcurrentHealth += 50;
           
        }

    }

    void DisableMovement()
    {
        controller.enabled = false; // Disable the player controller
        rigidbody2D.velocity = Vector2.zero; // Stop the player's velocity
        // Disable any other movement-related components or scripts here
    }

    void makeDeadWithDelay()
    {
        Destroy(gameObject);
        RecordScore(ScoreScript.curscore.ToString()); // Call the function to record the score
        SceneManager.LoadScene("gameover1"); // Load the "gameover1" scene
    }

    void RecordScore(string score)
    {
        string filePath = Application.dataPath + "/score.txt"; // Path to the text file
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(score); // Write the score to the text file
        }
    }
}
