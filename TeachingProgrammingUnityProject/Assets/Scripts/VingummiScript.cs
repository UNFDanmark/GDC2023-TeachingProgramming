using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VingummiScript : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;

    public SpawnerScript sraliboBag;
    public PointCounterScript pointCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,rotationSpeed,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sraliboBag.currentAmountOfGummies--;
            pointCounter.points += 10000;
            pointCounter.tmpText.text = "KCal: " + pointCounter.points;
            Destroy(gameObject);
        }
    }
}
