using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MainScene;
    [SerializeField]
    private GameObject hiddenScene;

    private float next = 1f;
    private bool fakeMainMenu = false;
    void Start()
    {
        MainScene.SetActive(true);
        hiddenScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fakeMainMenu)
        {
            MainScene.SetActive(false);
            hiddenScene.SetActive(true);
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
        SceneManager.LoadScene("Seb_Finalization"); //should send you back into the game
    }

    public void Home()
    {
        SceneManager.LoadScene("Title_Screen"); //should send you back to main menu
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
