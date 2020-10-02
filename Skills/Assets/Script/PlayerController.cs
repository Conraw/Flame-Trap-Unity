using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private SpriteRenderer mySpriteRender;
    public Animator playerAnim;

    public float fallMultipler = 6.22f;
    public float jumpForce = 11.5f;
    public float horizontalInput;
    public float speed = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    private Vector3 playerSize = new Vector3(3, 3, 3);

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Attack();
        Jump();
        Move();

        playerAnim.SetBool("Walk_b", false);
        if (horizontalInput != 0)
        {
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            playerAnim.SetBool("Walk_b", true);
        }
        
       
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.localScale = playerSize;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.localScale = new Vector3(-3, 3, 3);          
        }
    }

    void Jump()
    {
        if (playerRb.velocity.y < 0)
        {
            playerRb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultipler) * Time.deltaTime;
        }
        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
            {         
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
            }
        }
    }
    void Attack()
    {          
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetBool("Attack_b", true);
            Invoke("AttackBoolFalse", .6f);               
        }
    }
    void AttackBoolFalse()
    {
        playerAnim.SetBool("Attack_b", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        }
    }
}
