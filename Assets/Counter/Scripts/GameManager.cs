using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    // Range for spawning toys z is the same high and low so only one value is needed
    public float xRangeHigh = 5;
    public float xRangeLow = -32;
    public float zRange = 20;
    public Text Toy1Text;
    public Text Toy2Text;
    public Text Toy3Text;
    public int Count1 = 0;
    public int Count2 = 0;
    public int Count3 = 0;
    public ObjectPooler objectPoolerScript;
    public Button StartButton;
    public GameObject TitleScreen;
    public GameObject GameOverScreen;
    public GameObject CountingText;
    public AudioClip gameCompleteSound;

    private AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        objectPoolerScript = GameObject.Find("GameManager").GetComponent<ObjectPooler>();
        gameAudio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Count1 + Count2 + Count3 >= objectPoolerScript.amountToPool)
        {
            GameOverScreen.SetActive(true);
            CountingText.SetActive(false);
            //Time.timeScale = 0; // Pause the game
            gameAudio.PlayOneShot(gameCompleteSound, 0.5f);
        }
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
        for (int i = 0; i < objectPoolerScript.amountToPool; i++)
        {
            SpawnRandomToys();
        }
        TitleScreen.SetActive(false);
        CountingText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
