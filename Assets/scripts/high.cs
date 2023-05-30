using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class high : MonoBehaviour
{
    public Text highScoreText; // Reference to the Text component on the canvas

    void Start()
    {
        // Read the contents of the score.txt file
        string filePath = Application.dataPath + "/score.txt";
        if (File.Exists(filePath))
        {
            string scoreData = File.ReadAllText(filePath);
            int highestScore = 0;

            // Split the scores by newline character
            string[] scores = scoreData.Split('\n');

            // Iterate through each score and find the highest
            for (int i = 0; i < scores.Length; i++)
            {
                int score;
                if (int.TryParse(scores[i], out score))
                {
                    if (score > highestScore)
                    {
                        highestScore = score;
                    }
                }
            }

            // Display the highest score in the Text component
            highScoreText.text = "High Score: " + highestScore.ToString();
        }
        else
        {
            Debug.LogError("score.txt file not found!");
        }
    }

    void Update()
    {
        // Your other update logic
    }
}
