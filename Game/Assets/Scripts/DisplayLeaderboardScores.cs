using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLeaderboardScores : MonoBehaviour
{
    int ScoreLeaderboard1;
    int ScoreLeaderboard2;
    int ScoreLeaderboard3;
    int ScoreLeaderboard4;
    int ScoreLeaderboard5;

    void Start()
    {
        ScoreLeaderboard1 = PlayerPrefs.GetInt("ScoreLeaderboard1");
        ScoreLeaderboard2 = PlayerPrefs.GetInt("ScoreLeaderboard2");
        ScoreLeaderboard3 = PlayerPrefs.GetInt("ScoreLeaderboard3");
        ScoreLeaderboard4 = PlayerPrefs.GetInt("ScoreLeaderboard4");
        ScoreLeaderboard5 = PlayerPrefs.GetInt("ScoreLeaderboard5");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponentInParent<LeaderboardTimer>().getTriger())
        {
            ScoreLeaderboard1 = PlayerPrefs.GetInt("ScoreLeaderboard1");
            ScoreLeaderboard2 = PlayerPrefs.GetInt("ScoreLeaderboard2");
            ScoreLeaderboard3 = PlayerPrefs.GetInt("ScoreLeaderboard3");
            ScoreLeaderboard4 = PlayerPrefs.GetInt("ScoreLeaderboard4");
            ScoreLeaderboard5 = PlayerPrefs.GetInt("ScoreLeaderboard5");
            this.gameObject.GetComponent<TextMesh>().text = "\n" + ScoreLeaderboard1.ToString() + "\n"  + ScoreLeaderboard2.ToString() + "\n" + ScoreLeaderboard3.ToString() + "\n" + ScoreLeaderboard4.ToString() + "\n" + ScoreLeaderboard5.ToString();
        }
    }
}
