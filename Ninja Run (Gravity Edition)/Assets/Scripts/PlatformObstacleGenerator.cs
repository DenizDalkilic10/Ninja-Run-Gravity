using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObstacleGenerator : MonoBehaviour
{
    public Transform[] instantiationPoints;
    public GameObject[] obstacles;
   

   
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < instantiationPoints.Length; i++)
        {
            if ((int)Random.Range(0.0f, 4.0f) < GameController.levelMultiplier)
            {
                Debug.Log("Done");
                GameObject obstacle = obstacles[(int)Random.Range(0, obstacles.Length)];
                Instantiate(obstacle, instantiationPoints[i].position, obstacle.transform.rotation);
            }
        }
    }
}
