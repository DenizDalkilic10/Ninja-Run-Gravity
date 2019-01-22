using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public static string choice;
   
    // Start is called before the first frame update
    

    public void setChoice(string _choice) {
        choice = _choice;
        Debug.Log(choice);
    }

    public void loadGameScene(string _choice) {
        Time.timeScale = 1;
        Debug.Log("Loading Scene..." + _choice);
        setChoice(_choice);
        SceneManager.LoadScene("Game Scene");
    }
}
