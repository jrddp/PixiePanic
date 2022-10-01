using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorChange : MonoBehaviour
{
    public GameObject cube;
    private Renderer rend;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This will get the OBJECT to CHANGE COLOR on KEY PRESS
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.red;
            print("A Key Pressed For Red Color");
        }
        if (Input.GetKeyDown(KeyCode.B)) { 
            GetComponent<Renderer>().material.color = Color.blue;
            print("A Key Pressed For Blue Color");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Test");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player1")
        {
            print("Flag 1");
            transform.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (collision.gameObject.name == "Player2")
        {
            transform.GetComponent<Renderer>().material.color = Color.green;
        }

    }

}
