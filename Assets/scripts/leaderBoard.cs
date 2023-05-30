using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class leaderBoard : MonoBehaviour
{
    public Text scoreText; // Text component to display the contents

    void Start()
    {
        string filePath = Path.Combine(Application.dataPath, "score.txt");

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string formattedText = "";

            // Calculate the maximum width for each column
            int[] columnWidths = new int[3];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                for (int j = 0; j < data.Length; j++)
                {
                    if (data[j].Length > columnWidths[j])
                    {
                        columnWidths[j] = data[j].Length;
                    }
                }
            }

            // Format and align the contents in a table
            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                for (int j = 0; j < data.Length; j++)
                {
                    // Add padding to align the columns
                    string paddedData = data[j].PadRight(columnWidths[j]);

                    formattedText += paddedData;

                    if (j < data.Length - 1)
                    {
                        formattedText += " | ";
                    }
                }

                formattedText += "\n";
            }

            scoreText.text = formattedText;
        }
        else
        {
            Debug.Log("score.txt file does not exist.");
        }
    }
}
