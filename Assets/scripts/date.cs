using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityApplication = UnityEngine.Application;
using UnityDebug = UnityEngine.Debug;

public class date : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;

    void Start()
    {
        string filePath = Path.Combine(UnityApplication.dataPath, "score.txt");

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string formattedText = "";

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                if (data.Length == 3)
                {
                    string thirdIndex = data[2];
                    formattedText += thirdIndex;
                    formattedText += "\n";
                }
            }

            scoreText.text = formattedText;
        }
        else
        {
            UnityDebug.Log("score.txt file does not exist.");
        }
    }
}
