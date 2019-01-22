using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroupController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime* speed);
    }
}
