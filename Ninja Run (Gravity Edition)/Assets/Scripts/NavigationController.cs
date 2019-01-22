using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NavigationController : MonoBehaviour
{
    public Text coins;
    public GameObject pauseMenu;
    // Start is called before the first frame update

    private void Start()
    { 
        coins.text = "" + GameController.coins;       
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Game Scene"))
        {
            coins.text = "" + GameController.coins; 
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        GameController.paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void OpenMenu() {
        SceneManager.LoadScene("Main Menu");
        GameController.paused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

   
}
