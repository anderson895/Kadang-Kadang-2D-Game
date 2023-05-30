using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class save : MonoBehaviour
{
    public Button saveButton;
    public InputField inputField;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        saveButton.onClick.AddListener(SaveScore); // Attach the SaveScore function to the button's onClick event
    }

    void SaveScore()
    {
        RecordScore(ScoreScript.curscore.ToString(), inputField.text); // Call the function to record the score with the input data
        panel.SetActive(true); // Enable the panel component
    }

    void RecordScore(string score, string input)
    {
        string filePath = UnityEngine.Application.dataPath + "/score.txt"; // Path to the text file
        string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd"); // Get the current date in the format "yyyy-MM-dd"

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(score + "," + input + "," + currentDate); // Write the score, input, and current date to the text file
        }
    }

}
