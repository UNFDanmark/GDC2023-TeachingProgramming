using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject gummyCoin;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private int maxAmountOfGummies;
    [SerializeField] private Transform spawnArea;
    [SerializeField] private PointCounterScript _pointCounterScript;

    private float timeLeftBetweenSpawns;
    public int currentAmountOfGummies;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftBetweenSpawns -= Time.deltaTime;
        if (timeLeftBetweenSpawns <= 0 && currentAmountOfGummies < maxAmountOfGummies)
        {
            
            GameObject newGummy = Instantiate(gummyCoin,PositionRandomizer(),gummyCoin.transform.rotation);
            VingummiScript newGummyScript = newGummy.GetComponent<VingummiScript>();
            newGummyScript.sraliboBag = this;
            newGummyScript.pointCounter = _pointCounterScript;
            
            timeLeftBetweenSpawns = spawnCooldown;
            currentAmountOfGummies ++;
        }
        
    }

    Vector3 PositionRandomizer()
    {
        float x = Random.Range(-spawnArea.localScale.x/2, spawnArea.localScale.x/2);
        float z = Random.Range(-spawnArea.localScale.y/2, spawnArea.localScale.y/2);
        return new Vector3(x, 0.75f, z);
    }
}
