using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Required when using UI elements in the script.
using UnityEngine.SceneManagement; 

public class ScoreManager : MonoBehaviour {

    private int currentScoreCarnegie;
    private int currentScoreFairy;
    public Text displayScoreCarnagie;
    public Text displayScoreFairy;

    void Start()
    {
        currentScoreCarnegie = 0;
        currentScoreFairy = 0;
    }

    
    // Update is called once per frame
    void Update ()
    {
        currentScoreCarnegie = GameObject.FindGameObjectsWithTag("tile_red").Length;
        displayScoreCarnagie.text = currentScoreCarnegie.ToString();
       
        currentScoreFairy = GameObject.FindGameObjectsWithTag("tile_green").Length;
        displayScoreFairy.text = currentScoreFairy.ToString();
        
    }
}