using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public ObjectPooler objectPoolerScript;

    // Range for spawning toys z is the same high and low so only one value is needed
    public float xRangeHigh = 5;
    public float xRangeLow = -32;
    public float zRange = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnRandomToys();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomToys()
    {
        //Checks if pooled object should be of type enemy
        GameObject pooledToy = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledToy != null)
        {
            pooledToy.SetActive(true); // activate it
            
            pooledToy.transform.position = new Vector3(Random.Range(xRangeLow, xRangeHigh), 1,Random.Range(-zRange,zRange));
        }
    }
}
