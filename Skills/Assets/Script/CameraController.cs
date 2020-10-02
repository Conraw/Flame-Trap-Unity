using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        MainCamera = GameObject.Find("Camera");
  
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 26)
        {
            MainCamera.transform.position = new Vector3(56.9f, 2.1f, -12);
        }
    }
}
