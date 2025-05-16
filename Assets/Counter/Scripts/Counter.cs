using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public GameManager gameManagerScript;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy1"))
        {
            gameManagerScript.Count1 += 1;
            gameManagerScript.Toy1Text.text = "Count : " + gameManagerScript.Count1;
            other.gameObject.SetActive(false); // Deactivate the toy after counting
        }
        if (other.gameObject.CompareTag("Toy2"))
        {
            gameManagerScript.Count2 += 1;
            gameManagerScript.Toy2Text.text = "Count : " + gameManagerScript.Count2;
            other.gameObject.SetActive(false); // Deactivate the toy after counting
        }
        if (other.gameObject.CompareTag("Toy3"))
        {
            gameManagerScript.Count3 += 1;
            gameManagerScript.Toy3Text.text = "Count : " + gameManagerScript.Count3;
            other.gameObject.SetActive(false); // Deactivate the toy after counting
        }
    }
}
