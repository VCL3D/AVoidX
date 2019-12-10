using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    int totalSeconds;
    int remainingSeconds;
    bool GameStarts = false;
    int minutes;
    int seconds;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        remainingSeconds = totalSeconds;
        minutes = (int)remainingSeconds / 60;
        seconds = (int)remainingSeconds - 60 * minutes;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = minutes.ToString() + ":" + GetSeconds();
        if (GameStarts && counter < 2)
        {
            GameStarts = false;
            StartCoroutine(Timer());
        }
    }

    public void SetTotalSeconds(int val)
    {
        totalSeconds = val;
    }

    public void WallCollision()
    {
        GameStarts = true;
        counter++;
    }

    public int GetCounter()
    {
        return counter;
    }

    string GetSeconds()
    {
        if (seconds > 9) return seconds.ToString();
        else return "0"+ seconds.ToString();
    }

    private IEnumerator Timer()
    {
        while (remainingSeconds > 0)
        {
            remainingSeconds--;
            minutes = (int)remainingSeconds / 60;
            seconds = (int)remainingSeconds - 60 * minutes;
            yield return new WaitForSeconds(1f);
        }
        if (GameObject.Find("MenuController"))
        {
            GameObject.Find("MenuController").GetComponent<MenuController>().SetScore(GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().GetScore().ToString());
            SceneManager.LoadScene("GameOverScreen");
        }
    }
}
