using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody body;

    [SerializeField] private GameObject bullet;
    [SerializeField] Animator tankAnimator;
    [SerializeField] private Transform gunBarrel;
    [SerializeField] ParticleSystem gunParticles;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 1;
    [SerializeField] private float jumpSpeed = 1;
    [SerializeField] private float bulletLifeTime = 9;
    [SerializeField] private float bulletSpeed = 9;
    [SerializeField] private float cooldownTime = .9f;

    [SerializeField] public 
        int playerNumber;
    
    private float moveInput;
    private float turnInput;
    private bool isOnGround;
    private float timeLeftBetweenShots;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool jumpHasBeenPressed = false;
        bool fireButtonPressed = false;
        if (playerNumber == 1)
        {
            moveInput = Input.GetAxis("VerticalSral");
            turnInput = Input.GetAxis("HorizontalSral");
            jumpHasBeenPressed = Input.GetButtonDown("Jump");
            fireButtonPressed = Input.GetButtonDown("FireSral");
        }
        
        if (playerNumber == 2)
        {
            moveInput = Input.GetAxis("VerticalRasl");
            turnInput = Input.GetAxis("HorizontalRasl");
            jumpHasBeenPressed = Input.GetButtonDown("Jump");
            fireButtonPressed = Input.GetButtonDown("FireRasl");
        }

        // V1
        if (moveInput != 0)
        {
            tankAnimator.SetBool("IsDriving", true);
        }
        else
        {
            tankAnimator.SetBool("IsDriving", false);
        }

        timeLeftBetweenShots -= Time.deltaTime;
        
        if (jumpHasBeenPressed && isOnGround)
        {
            body.velocity = Vector3.up * jumpSpeed;
            isOnGround = false;
        }

        if (fireButtonPressed && timeLeftBetweenShots <= 0)
        {
            // animate
            tankAnimator.SetTrigger("Shoot");
            
            // sound
            AudioSource soundSource = gameObject.GetComponent<AudioSource>();
            soundSource.timeSamples = (int)(soundSource.clip.frequency * 1.05f);
            soundSource.Play();
            
            // particle
            gunParticles.Play();
            
            GameObject newBullet = Instantiate(bullet,gunBarrel.position,transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            Destroy(newBullet,bulletLifeTime);
            timeLeftBetweenShots = cooldownTime;
        }
        
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up,turnSpeed * turnInput);
        Vector3 moveVector = transform.forward * (speed * moveInput);
        moveVector.y = body.velocity.y;
        body.velocity = moveVector;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jord"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jord"))
        {
            isOnGround = false;
        }
    }
}
