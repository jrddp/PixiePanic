using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
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
