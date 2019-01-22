using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x,transform.position.y,transform.position.z);
    }
}
