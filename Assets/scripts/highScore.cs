using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityApplication = UnityEngine.Application;
using UnityDebug = UnityEngine.Debug;

public class highScore : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;

    void Start()
    {
        string filePath = Path.Combine(UnityApplication.dataPath, "score.txt");

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string formattedText = "";

            int highestValue = int.MinValue;
            string highestLine = "";

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                if (data.Length >= 2)
                {
                    int firstIndexValue = int.Parse(data[0]);

                    if (firstIndexValue > highestValue)
                    {
                        highestValue = firstIndexValue;
                        highestLine = lines[i];
                    }
                }
                else
                {
                    UnityDebug.Log("Invalid format in line " + (i + 1) + " of score.txt");
                }
            }

            string[] highestData = highestLine.Split(',');
            if (highestData.Length >= 2)
            {
                formattedText = highestData[0] + ", " + highestData[1];
            }

            scoreText.text = formattedText;
        }
        else
        {
            UnityDebug.Log("score.txt file does not exist.");
        }
    }
}
