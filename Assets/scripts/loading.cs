using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public Image fillImage;
    public float duration = 3f;
    public string nextSceneName = "level1";

    private float initialFillAmount;
    private float targetFillAmount;
    private float fillAmountSpeed;
    private float elapsedTime;

    private void Start()
    {
        fillImage.fillAmount = 0f; // Start with zero fill amount
        initialFillAmount = fillImage.fillAmount;
        targetFillAmount = 1f; // Target fill amount of 1 (fully filled)
        fillAmountSpeed = (targetFillAmount - initialFillAmount) / duration; // Calculate fill amount speed
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (fillImage.fillAmount < targetFillAmount)
        {
            elapsedTime += Time.deltaTime;
            float newFillAmount = initialFillAmount + (fillAmountSpeed * elapsedTime);
            fillImage.fillAmount = Mathf.Clamp01(newFillAmount); // Clamp fill amount between 0 and 1
        }

        // Open the next scene after 3 seconds
        if (elapsedTime >= duration)
        {
            ResetScore(); // Reset the score before loading the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void ResetScore()
    {
        ScoreScript.curscore = 0; // Reset the score to 0
        // You can also reset the score text component here if needed
    }
}
