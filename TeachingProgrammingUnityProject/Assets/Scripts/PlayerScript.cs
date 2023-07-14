using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody body;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 1;
    [SerializeField] private float jumpSpeed = 1;

    private float moveInput;
    private float turnInput;
    private bool isOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            body.velocity = Vector3.up * jumpSpeed;
            isOnGround = false;
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
