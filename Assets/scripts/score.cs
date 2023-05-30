using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityApplication = UnityEngine.Application; // Specify the full namespace for UnityEngine.Application
using UnityDebug = UnityEngine.Debug; // Specify the full namespace for UnityEngine.Debug

public class score : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText; // Specify the full namespace for UnityEngine.UI.Text

    void Start()
    {
        string filePath = Path.Combine(UnityApplication.dataPath, "score.txt"); // Use UnityApplication.dataPath

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string formattedText = "";

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                if (data.Length == 3)
                {
                    string firstIndex = data[0];
                    formattedText += firstIndex;
                    formattedText += "\n";
                }
            }

            scoreText.text = formattedText;
        }
        else
        {
            UnityDebug.Log("score.txt file does not exist."); // Use UnityDebug.Log
        }
    }
}
