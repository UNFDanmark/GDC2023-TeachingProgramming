using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VingummiScript : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;

    public SpawnerScript sraliboBag;
    
    [FormerlySerializedAs("pointCounter")]
    public PointCounterScript sralScore;
    public PointCounterScript raslScore;
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
            if (other.GetComponent<PlayerScript>().playerNumber == 1)
            {
                sralScore.points += 10000;
                sralScore.tmpText.text = "KCal: " + sralScore.points;
            }
            
            if (other.GetComponent<PlayerScript>().playerNumber == 2)
            {
                raslScore.points += 10000;
                raslScore.tmpText.text = "KCal: " + raslScore.points;
            }
            
            sraliboBag.currentAmountOfGummies--;
            Destroy(gameObject);
        }
    }
}
