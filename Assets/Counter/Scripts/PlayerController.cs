using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManagerScript;
    public float speed = 10.0f; // Speed of the player
    public float rotateSpeed = 50.0f; // Speed of the player
    private float horizontalInput;
    private float VerticalInput;
    private float yRangeHigh = 10;
    private float yRangeLow = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        // Move the player
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotateSpeed);
        transform.Translate(Vector3.forward * VerticalInput * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        // Clamp the player's position to the screen bounds
        RestrictPlayer();
    }

    private void RestrictPlayer()
    {
        if (transform.position.x < gameManagerScript.xRangeLow)
        {
            transform.position = new Vector3(gameManagerScript.xRangeLow, transform.position.y, transform.position.z);
        }
        if (transform.position.x > gameManagerScript.xRangeHigh)
        {
            transform.position = new Vector3(gameManagerScript.xRangeHigh, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -gameManagerScript.zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -gameManagerScript.zRange);
        }
        if (transform.position.z > gameManagerScript.zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, gameManagerScript.zRange);
        }
        if (transform.position.y < yRangeLow)
        {
            transform.position = new Vector3(transform.position.x, yRangeLow, transform.position.z);
        }
        if (transform.position.y > yRangeHigh)
        {
            transform.position = new Vector3(transform.position.x, yRangeHigh, transform.position.z);
        }
    }
}
