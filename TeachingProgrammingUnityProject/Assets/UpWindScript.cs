using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWindScript : MonoBehaviour
{
    [SerializeField] float upwardsForce = 10f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody otherBody = other.attachedRigidbody;
            Vector3 currentVelocity = otherBody.velocity;
            currentVelocity.y += upwardsForce;
            otherBody.velocity = currentVelocity;
        }
    }
}
