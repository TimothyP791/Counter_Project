using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text Toy1Text;
    public Text Toy2Text;
    public Text Toy3Text;

    private int Count1 = 0;
    private int Count2 = 0;
    private int Count3 = 0;

    private void Start()
    {
        Count1 = 0;
        Count2 = 0;
        Count3 = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy1"))
        {
            Count1 += 1;
            Toy1Text.text = "Count : " + Count1;
        }
        if (other.gameObject.CompareTag("Toy2"))
        {
            Count2 += 1;
            Toy2Text.text = "Count : " + Count2;
        }
        if (other.gameObject.CompareTag("Toy3"))
        {
            Count3 += 1;
            Toy3Text.text = "Count : " + Count3;
        }
    }
}
