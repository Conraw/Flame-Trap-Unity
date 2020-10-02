using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private DetectCollision detectCollisionScript;
    public Transform door;
    public Transform player;

    private Vector3 closedPosition1 = new Vector3(25.289f, 12.1f, 53.881f);
    private Vector3 openedPosition1 = new Vector3(25.289f, -5.1f, 53.881f);

    private Vector3 closedPosition2 = new Vector3(86.546f, 10.024f, 86.821f);
    private Vector3 openedPosition2 = new Vector3(86.546f, -7.4f, 86.821f);
    public int coinsDestroyed = 0;

    bool doorOne = true;
    bool doorTwo = false;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        detectCollisionScript = GameObject.Find("Coins").GetComponent<DetectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOne)
        {
            CloseDoorOne();
            if (coinsDestroyed == 3)
            {
                OpenDoorOne();
                doorTwo = true;
            }
            CloseDoorOne();
        }

        if (doorTwo)
        {
            if (coinsDestroyed == 6)
            {
                OpenDoorTwo();              
            }
            CloseDoorTwo();
        }
    }
    void OpenDoorOne()
    {      
        door.position = openedPosition1; 
    }
    void CloseDoorOne()
    {       
        if (playerControllerScript.transform.position.x > 29)
        {
            door.position = closedPosition1;
            doorOne = false;
        }
    }
    void OpenDoorTwo()
    {
        door.position = openedPosition2;
    }
    void CloseDoorTwo()
    {
        if (playerControllerScript.transform.position.x > 90)
        {
            door.position = closedPosition2;
            doorTwo = false;
        }
    }
}
