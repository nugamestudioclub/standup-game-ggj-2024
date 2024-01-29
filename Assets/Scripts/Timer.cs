using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject fadeOut;
    [SerializeField] Animator animator;
    float startingTime;
    bool timerRunning = true;
    bool warningGiven = false;
    bool lastWarning = false;
    Coroutine flashing;
    Canvas canvas;

    IEnumerator BlinkGameOverText(float flashtime)
    {
        //Debug.Log("Time here: " + flashtime);
        while (remainingTime > 0f)
        {
            //Debug.Log("In warning");
            timerText.enabled = true; // Ensure text is visible
            yield return new WaitForSeconds(flashtime); // Display text for 0.5 seconds
            timerText.enabled = false; // Hide text
            yield return new WaitForSeconds(flashtime); // Hide text for 0.5 seconds
        }
    }

    void Start()
    {
        //StartCoroutine(BlinkGameOverText());
        startingTime = remainingTime;
        animator.SetBool("Transition", false);
        canvas = GetComponent<Canvas>();
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
                StopCoroutine(flashing);
                timerText.text = "<color=red>Game Over</color>"; // Set timerText to display "Game Over" in red
                timerText.enabled = true; // Ensure the text is visible
                animator.SetBool("Transition", true);
                canvas.sortingOrder = 1;
            }
            else
            {
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                if (startingTime / remainingTime >= 2f && !warningGiven)
                {
                    warningGiven = true;
                    //Debug.Log("Warning");
                    flashing = StartCoroutine(BlinkGameOverText(0.5f));
                }
                else if (startingTime / remainingTime >= 4f && !lastWarning)
                {
                    lastWarning = true;
                    StopCoroutine(flashing);
                    flashing = StartCoroutine(BlinkGameOverText(0.25f));
                    //Debug.Log("i stopped");
                }
                if (lastWarning)
                {
                    timerText.text = "<color=orange>" + timerText.text + "</color>";
                }
                else if (warningGiven)
                {
                    timerText.text = "<color=yellow>" + timerText.text + "</color>";
                }
            }
        }
    }
}
