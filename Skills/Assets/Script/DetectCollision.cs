using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerControllerScript;
    private AudioSource playerAudio;
    public DoorController doorControllerScript;
    public AudioClip shatterSound;
    public ParticleSystem shatterParticle;



    // Start is called before the first frame update
    void Start()
    {
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Fireball")
        {
            gameManager.GameOver();    
        }
        if (other.tag == "Player" && this.tag == "Coin" && playerControllerScript.playerAnim.GetBool("Attack_b"))
        {          
            doorControllerScript.coinsDestroyed++;
            
            ShatterParticle();                 
            Destroy(gameObject);
            playerAudio.PlayOneShot(shatterSound, 1f);        
        }
    }

    void ShatterParticle()
    {
        Vector3 spawnPos = this.transform.position;
        ParticleSystem newParticle = Instantiate(shatterParticle, spawnPos, transform.rotation);
        newParticle.Play();
     
        Destroy(newParticle, .5f);
    }
  
    
}
