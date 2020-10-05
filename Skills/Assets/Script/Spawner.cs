using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject fireball;
    public float projectileSpeed;
    public GameObject player;
    private PlayerController playerControllerScript;

    private float startDelay = 1;
    private float spawnInterval = 1000;

    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFireball", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    void SpawnFireball()
    {
        if (playerControllerScript.transform.position.x < 29)
        {
            spawnPos = new Vector3(Random.Range(-36, 23), 24.5f, 60);
            spawnInterval = 2f;
        }
        else if (playerControllerScript.transform.position.x < 90)
        {
            spawnPos = new Vector3(Random.Range(29, 84), 24.5f, 60);
            spawnInterval = 1.5f;
        }
        else if (playerControllerScript.transform.position.x < 150)
        {
            spawnPos = new Vector3(Random.Range(90, 150), 24.5f, 60);
            spawnInterval = 1f;
        }
        else if (playerControllerScript.transform.position.x < 219.2f)
        {
            int randomBreak = Random.Range(174, 198);
            for (int i = 160; i < 211; i++)
            {
                if (i == randomBreak)
                {
                    i += 5;
                }
                else
                {
                    spawnPos = new Vector3(i, 24.5f, 60);
                    spawnInterval = 5f;
                    Instantiate(fireball, spawnPos, transform.rotation);
                }
            }
        }


        Instantiate(fireball, spawnPos, transform.rotation);
        Invoke("SpawnFireball", spawnInterval);
    }

}
