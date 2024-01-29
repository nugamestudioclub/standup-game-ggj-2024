using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimerHandler : MonoBehaviour
{
    [SerializeField]
    [Tooltip("In seconds")]
    private float timeUntilTransition = 180;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToExit());
    }

    IEnumerator WaitToExit()
    {
        yield return new WaitForSeconds(timeUntilTransition);
        //SceneHandler.TransitionTo(winScene);
        if (JokeButtonManager.buttonsHit > 0) {
            SceneManager.LoadScene("NotFunny...");
        } else {
            SceneManager.LoadScene("YouWin!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
