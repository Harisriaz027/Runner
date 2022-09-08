using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10f;
    public bool doubleJump;
    public bool flyMode;
    public int count;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip coinSound;
    void Start()
    {
        flyMode = false;
        count = 0;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier; 
    }

    void Update()
    {
        if (isOnGround)
        {
            doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround&&!gameOver&&!flyMode)
        {
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound,3.0f);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump&&!gameOver&&!flyMode)
        {
            playerRb.AddForce(Vector3.up * jumpForce*0.5f, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound,3.0f);
            isOnGround = false;
            doubleJump = false;
           
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            flyMode = !flyMode;
            playerRb.useGravity = !playerRb.useGravity;

        }
        if (!gameOver)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
        }
        if (flyMode==true)
        {
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAudio.PlayOneShot(crashSound);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        count++;
        playerAudio.PlayOneShot(coinSound,1.0f);
        Destroy(other.gameObject);
    }
}
