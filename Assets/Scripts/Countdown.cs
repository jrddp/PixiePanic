using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    //public GameOverScreen GameOverScreen;
    //public ScoreManager ScoreManager;
    public int countdownTime;
    public Text countdownDisplay;

    //public Text ScoreDisplay;
    IEnumerator CountdownOfGame()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        if (countdownTime == 0)
        {

            //SceneManager.LoadScene(2);

        }
        countdownDisplay.text = "STOP";

        int currentScoreCarnegie = GameObject.FindGameObjectsWithTag("tile_red").Length;
        int currentScoreFairy = GameObject.FindGameObjectsWithTag("tile_green").Length;

        if (currentScoreCarnegie > currentScoreFairy) {
          SceneManager.LoadScene(4);
        } else if (currentScoreFairy > currentScoreCarnegie) {
          SceneManager.LoadScene(3);
        } else {
          // display tie ???
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownOfGame());


    }

    // Update is called once per frame
    void Update()
    {

    }
}
