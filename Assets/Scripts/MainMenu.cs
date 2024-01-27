using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        SceneManager.LoadScene("Sample Scene"); //should send you back into the game
    }

    public void Home()
    {
        SceneManager.LoadScene("Sample Scene"); //should send you back to main menu
    }
}
