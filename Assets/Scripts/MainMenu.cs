using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Text;
    [SerializeField]
    private GameObject hiddenScene;

    private float next = 1f;
    private bool fakeMainMenu = false;
    void Start()
    {
        Text.SetActive(true);
        hiddenScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fakeMainMenu)
        {
            Text.SetActive(false);
            hiddenScene.SetActive(true);
            if (next <= 0f)
            {
                Quit();
            }
            else
            {
                next -= Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("Working...");
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
