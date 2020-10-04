using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private DetectCollision detectCollisionScript;
    public Transform door;

    public int coinsDestroyed = 0;

    // Start is called before the first frame update
    void Start()
    {
        detectCollisionScript = GameObject.Find("Coins").GetComponent<DetectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coinsDestroyed == 3)
        {
            Destroy(GameObject.Find("Wall1"));
        }
        if (coinsDestroyed == 4)
        {
            Destroy(GameObject.Find("Wall2"));
        }                   
    }
}
