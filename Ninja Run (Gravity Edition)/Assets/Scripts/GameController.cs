using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public static bool paused;
    public static int levelMultiplier;
    [HideInInspector]
    private int score;
    public static int coins;
    public enum GameMode {Classic , Survival};
    public static GameMode gameMode;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
       
        Debug.Log("GameController Activated.");
        Debug.Log("Choice: " + MenuController.choice);
        if (MenuController.choice.Equals("Classic"))
            gameMode = GameMode.Classic;
        else if (MenuController.choice.Equals("Survival"))
            gameMode = GameMode.Survival;

        //Init game mode according to input from main screen
        levelMultiplier = 0;
        paused = true;
        score = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            if ((int)(player.transform.position.x) % 10 == 0)
            {
                score += 1;
            }

            if (score % 50 == 0)
            {
                levelMultiplier++;
            }
            Debug.Log("Score: " + score);
        }
    }

    

    public string getGameMode() {
        if (gameMode == GameMode.Classic)
            return "Classic";
        else if (gameMode == GameMode.Survival)
            return "Survival";
        else
            return "";
    }

    public void setGameMode(string mode) {
        if (mode.Equals("Classic"))
            gameMode = GameMode.Classic;
        else if (mode.Equals("Survival"))
            gameMode = GameMode.Survival;
    }
}
