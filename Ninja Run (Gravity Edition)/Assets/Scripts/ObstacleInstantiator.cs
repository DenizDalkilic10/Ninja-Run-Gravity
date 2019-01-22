using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiator : MonoBehaviour
{
    public GameObject platformGenerator;
    public GameObject[] coinLoads;
    private PlatformGenerator generator;
    private Range coinRange;
   
    private float coinFrequency;
    private float obstacleFrequency;
    private float lastCoinLoad;
    
   
    // Start is called before the first frame update
    void Start()
    {
        coinRange = new Range(3,-2.50f);
       
        coinFrequency = 10.0f;
        lastCoinLoad = Time.time;
        generator = platformGenerator.GetComponent<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCoinLoad > coinFrequency)
        {
            lastCoinLoad = Time.time;
            Vector3 instantiationPoint = new Vector3(generator.getLastAddedPlatform().transform.position.x+10, Random.Range(coinRange.lowerLimit, coinRange.upperLimit), 0);
            GameObject coinLoad = Instantiate(coinLoads[0],instantiationPoint,generator.getLastAddedPlatform().transform.rotation);
            Destroy(coinLoad, 15f);
        }

    }

    //inner class for keeping upper and lower limit together
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
