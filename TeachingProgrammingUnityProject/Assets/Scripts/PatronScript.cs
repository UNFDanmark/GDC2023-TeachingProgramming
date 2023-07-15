using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronScript : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;

    private LayerMask explosionMask;
    
    // Start is called before the first frame update
    void Start()
    {
        explosionMask = LayerMask.GetMask("Player","Targets");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Collider[] victims = Physics.OverlapSphere(transform.position, explosionRadius,explosionMask);
        foreach (Collider victim in victims)
        {
            Rigidbody victimBody = victim.GetComponent<Rigidbody>();
            Vector3 direction = (victim.transform.position - transform.position).normalized;
            victimBody.AddForce(direction* explosionForce,ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}
