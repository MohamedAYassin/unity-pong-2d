using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update()
    {
       
    }

    public void Game()
    {
        SceneManager.LoadScene("Pong");
    }
    public void Quit()
    {
        Application.Quit();
    }
}