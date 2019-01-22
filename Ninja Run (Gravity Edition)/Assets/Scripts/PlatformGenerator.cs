using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    private GameObject platform;
    private GameObject lastAddedPlatform;
    public Transform generationPoint;
    private float platformLength;
    private float generationGap;
    private string GameMode;
    public GameObject Controller;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
       
        gameController = Controller.GetComponent<GameController>();
        GameMode = gameController.getGameMode();
        Debug.Log("Game mode: " + GameMode);
        if (GameMode.Equals("Classic"))
        {
            platform = platformPrefabs[0];
            generationGap = 10.1f;
        }
        else if (GameMode.Equals("Survival"))
        {
            platform = platformPrefabs[1];
            generationGap = 24.3f;
        }
        platform.SetActive(true);
       
        lastAddedPlatform = platform;
        //generationPoint.position = new Vector3(platform.transform.position.x, generationPoint.position.y, generationPoint.position.z);
        platformLength = platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
   
        if (generationPoint.position.x  >= (lastAddedPlatform.transform.position.x))
        {
            if (GameMode.Equals("Classic"))
            {
                Vector3 instantiationPosition = lastAddedPlatform.transform.position;
                instantiationPosition.x += platformLength / 2 + generationGap;
                lastAddedPlatform = Instantiate(platform, instantiationPosition, platform.transform.rotation);
                Destroy(lastAddedPlatform, 25.0f);
            }
            else if(GameMode.Equals("Survival")){
                Vector3 instantiationPosition = lastAddedPlatform.transform.position;
                instantiationPosition.x += platformLength / 2 + generationGap;
                lastAddedPlatform = Instantiate(platform, instantiationPosition, platform.transform.rotation);
                Destroy(lastAddedPlatform, 35.0f);
            }
        }
    }

    public GameObject getLastAddedPlatform() {
        return lastAddedPlatform;
    }

   
}
