using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{
    public int green = 0;
    public int red = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(green);
        Debug.Log(red);
    }

    void redUp()
    {
        red++;
    }

    void redDown()
    {
        red--;
    }

    void greenUp()
    {
        green++;
    }

    void greenDown()
    {
        green--;
    }


}
