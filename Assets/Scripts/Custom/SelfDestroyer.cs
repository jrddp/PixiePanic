using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    
    public float delay = 2.0f;

    // Use this for initialization
    void Start()
    {
         Object.Destroy(gameObject, delay);
    }

}
