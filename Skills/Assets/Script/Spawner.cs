using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fireball;
    public float projectileSpeed;
    public GameObject player;
    private PlayerController playerControllerScript;

    private float startDelay = 1;
    private float spawnInterval = 2f;

    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFireball", startDelay, spawnInterval );
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
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
        }
        else if (playerControllerScript.transform.position.x < 90)
        {
            spawnPos = new Vector3(Random.Range(29, 84), 24.5f, 60);
            spawnInterval = 1f;
        }
        Instantiate(fireball, spawnPos, transform.rotation);
    }
}
