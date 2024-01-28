using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MainScene;

    private float next = 1f;
    private bool fakeMainMenu = false;
    void Start()
    {
        MainScene.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (fakeMainMenu)
        {
            MainScene.SetActive(false);
            if (next <= 0f)
            {
                Debug.Log("Quits");
                Quit();
            }
            else
            {
                next -= Time.deltaTime;
            }
        }
        else
        {
            //Debug.Log("Working...");
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Sample Scene"); //should send you back into the game
    }

    public void Home()
    {
        SceneManager.LoadScene("Sample Scene"); //should send you back to main menu
    }

    public void fakeHome()
    {
        fakeMainMenu = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
