using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    // Range for spawning toys z is the same high and low so only one value is needed
    public float xRangeHigh = 5;
    public float xRangeLow = -32;
    public float zRange = 20;
    public Button StartButton;
    public GameObject TitleScreen;
    public GameObject GameOverScreen;
    public GameObject CountingText;
    public Counter counterScript;


    // Start is called before the first frame update
    void Start()
    {
        counterScript = GameObject.Find("Counting Text").GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
       /*if (counterScript.Count1 + counterScript.Count2 + counterScript.Count3 >= 10)
        {
            GameOverScreen.SetActive(true);
            CountingText.SetActive(false);
            //Time.timeScale = 0; // Pause the game
        }*/
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

    public void StartGame()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnRandomToys();
        }
        TitleScreen.SetActive(false);
        CountingText.SetActive(true);
    }
}
