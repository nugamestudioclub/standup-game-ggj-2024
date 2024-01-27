using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    bool timerRunning = true;

    IEnumerator BlinkGameOverText()
    {
        while (true)
        {
            timerText.enabled = true; // Ensure text is visible
            yield return new WaitForSeconds(0.5f); // Display text for 0.5 seconds
            timerText.enabled = false; // Hide text
            yield return new WaitForSeconds(0.5f); // Hide text for 0.5 seconds
        }
    }
    
    void Start()
    {
        StartCoroutine(BlinkGameOverText());
    }

    void Update()
    {
        if (timerRunning)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                timerRunning = false;
                StopCoroutine(BlinkGameOverText());
                timerText.text = "<color=red>Game Over</color>"; // Set timerText to display "Game Over" in red
                timerText.enabled = true; // Ensure the text is visible
            }
            else
            {
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }
}
