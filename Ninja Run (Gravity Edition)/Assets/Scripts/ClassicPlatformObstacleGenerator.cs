using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicPlatformObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;
    private float platformSize;
    private float obstacleSize;
    private int numberOfObstacles;
    private Range range_low;
    private Range range_high;
    private int gap;
    public GameObject player;
    public static bool playerInstantiated = false;
    // Start is called before the first frame update
    void Start()
    {
       
        platformSize = gameObject.GetComponent<BoxCollider2D>().size.x;
        obstacleSize = obstacle.GetComponent<BoxCollider2D>().size.x;
        numberOfObstacles = (int) (platformSize / obstacleSize);

        float x = transform.position.x - 4*obstacleSize;
        range_low = new Range(-4.1f, -2f);
        range_high = new Range(2f, 4.5f);
        gap = 3;

        Vector3 positionOfLastObstacle = new Vector3(0,0,0);

        for (int i = 0; i< numberOfObstacles; i++)
        {
            float y;
            if(i % 2 == 0)
                y = Random.Range(range_low.lowerLimit, range_low.upperLimit);
            else
                y = Random.Range(range_high.lowerLimit, range_high.upperLimit);
            

            Vector3 position = new Vector3(x,y,0);
           
            Instantiate(obstacle, position, transform.rotation);
            positionOfLastObstacle = position;

            if (i == 0 && !playerInstantiated)
            {
                position.y++;
                position.x++;
                player.transform.position = position;
                
                playerInstantiated = true;
            }
            x += obstacleSize;
        }
    }

    public class Range
    {
        public float upperLimit;
        public float lowerLimit;

        public Range(float upper, float lower)
        {
            upperLimit = upper;
            lowerLimit = lower;
        }

    }
}
