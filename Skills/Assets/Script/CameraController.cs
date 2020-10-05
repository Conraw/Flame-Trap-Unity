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
        if (player.transform.position.x > -36 && player.transform.position.x < 26.7f)
        {
            MainCamera.transform.position = new Vector3(-7.1f, 2.1f, -12);
        }
        else if (player.transform.position.x > 26.7f && player.transform.position.x < 84)
        {
            MainCamera.transform.position = new Vector3(56.9f, 2.1f, -12);
        }
        else if (player.transform.position.x > 90f && player.transform.position.x < 151)
        {
            MainCamera.transform.position = new Vector3(119.9f, 2.1f, -12);
        }
        else if (player.transform.position.x > 156f && player.transform.position.x < 217.2)
        {
            MainCamera.transform.position = new Vector3(187f, 2.1f, -12);
        }
    }
}
