using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public DoorController doorControllerScript;

  
    // Start is called before the first frame update
    void Start()
    {
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Fireball")
        {
            Destroy(other.gameObject);
            Debug.Log("Ive been hit");
        }
        if (other.tag == "Player" && this.tag == "Coin" && playerControllerScript.playerAnim.GetBool("Attack_b"))
        {
            doorControllerScript.coinsDestroyed++;
            Destroy(gameObject);
            Debug.Log("One more down");
        }
    }

}
