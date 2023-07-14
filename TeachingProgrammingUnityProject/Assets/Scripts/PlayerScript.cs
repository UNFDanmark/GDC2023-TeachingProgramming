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

    [SerializeField] private Transform gunBarrel;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 1;
    [SerializeField] private float jumpSpeed = 1;
    [SerializeField] private float bulletLifeTime = 9;
    [SerializeField] private float bulletSpeed = 9;
    [SerializeField] private float cooldownTime = .9f;

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
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        timeLeftBetweenShots -= Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            body.velocity = Vector3.up * jumpSpeed;
            isOnGround = false;
        }

        if (Input.GetButtonDown("Fire1") && timeLeftBetweenShots <= 0)
        {
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
