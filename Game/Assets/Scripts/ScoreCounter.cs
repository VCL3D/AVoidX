using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int Score;
    string NameLeaderboard1;
    string NameLeaderboard2;
    string NameLeaderboard3;
    string NameLeaderboard4;
    string NameLeaderboard5;
    int ScoreLeaderboard1;
    int ScoreLeaderboard2;
    int ScoreLeaderboard3;
    int ScoreLeaderboard4;
    int ScoreLeaderboard5;

    string tempNameLeaderboard;
    int tempScoreLeaderboard;

    bool isOnLeaderboard = false;
    string playerName;
    int ScoreToReach;
    float updateRate = 2f;
    float dt = 0.0f;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
       /* for (int i = 1; i < 6; i++)
        {
            PlayerPrefs.SetString("NameLeaderboard" + i.ToString(), "<Empty>");
            PlayerPrefs.SetInt("ScoreLeaderboard" + i.ToString(), 0);
        }*/


        NameLeaderboard1 = PlayerPrefs.GetString("NameLeaderboard1");
        NameLeaderboard2 = PlayerPrefs.GetString("NameLeaderboard2");
        NameLeaderboard3 = PlayerPrefs.GetString("NameLeaderboard3");
        NameLeaderboard4 = PlayerPrefs.GetString("NameLeaderboard4");
        NameLeaderboard5 = PlayerPrefs.GetString("NameLeaderboard5");
        ScoreLeaderboard1 = PlayerPrefs.GetInt("ScoreLeaderboard1");
        ScoreLeaderboard2 = PlayerPrefs.GetInt("ScoreLeaderboard2");
        ScoreLeaderboard3 = PlayerPrefs.GetInt("ScoreLeaderboard3");
        ScoreLeaderboard4 = PlayerPrefs.GetInt("ScoreLeaderboard4");
        ScoreLeaderboard5 = PlayerPrefs.GetInt("ScoreLeaderboard5");


        playerName = GameObject.Find("GameController").GetComponent<GameController>().GetPlayerName();

        counter = 6;

        if (playerName != "Guest")
        {
            while (!(isOnLeaderboard || counter <2))
            {
                counter--;
                if (playerName == PlayerPrefs.GetString("NameLeaderboard" + counter.ToString())) isOnLeaderboard = true;  
            }

            if (isOnLeaderboard) ScoreToReach = PlayerPrefs.GetInt("ScoreLeaderboard" + counter.ToString());
            else
            {
                ScoreToReach = PlayerPrefs.GetInt("ScoreLeaderboard5");
                counter = 6;
            }
        }

        Score = 0;
        GetComponent<TextMesh>().text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = Score.ToString();
        /*dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            if (playerName != "Guest!!!!")
            {
                if (Score > ScoreToReach)
                {
                    if (counter == 1)
                    {
                        PlayerPrefs.SetInt("ScoreLeaderboard" + counter.ToString(), Score);
                        ScoreToReach = Score;
                    }
                    else
                    {
                        if (counter == 6)
                        {
                            if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard4"))
                            {
                                PlayerPrefs.SetInt("ScoreLeaderboard5", Score);
                                PlayerPrefs.SetString("NameLeaderboard5", playerName);
                                counter = 5;
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard3"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard4", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", Score);
                                counter = 4;
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard3", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                                counter = 3;
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard2", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                                counter = 2;
                            }
                            else
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                                PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard1", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                                counter = 1;
                            }
                            ScoreToReach = Score;
                        }
                        else if (counter == 5)
                        {
                            if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard4"))
                            {
                                PlayerPrefs.SetInt("ScoreLeaderboard5", Score);
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard3"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard4", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", Score);
                                counter = 4;
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard3", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                                counter = 3;
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard2", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                                counter = 2;
                            }
                            else
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                                PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                                PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard1", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                                counter = 1;
                            }
                            ScoreToReach = Score;
                        }
                        else if (counter == 4)
                        {
                            if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard3"))
                            {
                                PlayerPrefs.SetInt("ScoreLeaderboard4", Score);
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard3", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                                counter = 3;
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard2", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                                counter = 2;
                            }
                            else
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                                PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                                PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard1", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                                counter = 1;
                            }
                            ScoreToReach = Score;
                        }
                        else if (counter == 3)
                        {
                            if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                            {
                                PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                            }
                            else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard2", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                                counter = 2;
                            }
                            else
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                                PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                                PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard1", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                                counter = 1;
                            }
                            ScoreToReach = Score;
                        }
                        else if (counter == 2)
                        {
                            if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                            {
                                PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                            }
                            else
                            {
                                tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                                tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                                PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                                PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                                PlayerPrefs.SetString("NameLeaderboard1", playerName);
                                PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                                counter = 1;
                            }
                            ScoreToReach = Score;
                        }
                    }
                }
            }

            dt -= (float)(1.0 / updateRate);
        }*/
    }

    public void ScoreUp(int x)
    {
        Score += x;
        GetComponent<TextMesh>().text = Score.ToString();
    }

    public void ScoreDown(int x)
    {
        if (Score > x) Score -= x;
        else Score = 0;
        GetComponent<TextMesh>().text = Score.ToString();
    }

    public int GetScore()
    {
        return Score;
    }

    public void LeaderboardCheck()
    {
        if (playerName != "Guest")
        {
            if (Score > ScoreToReach)
            {
                if (counter == 1)
                {
                    PlayerPrefs.SetInt("ScoreLeaderboard" + counter.ToString(), Score);
                    ScoreToReach = Score;
                }
                else
                {
                    if (counter == 6)
                    {
                        if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard4"))
                        {
                            PlayerPrefs.SetInt("ScoreLeaderboard5", Score);
                            PlayerPrefs.SetString("NameLeaderboard5", playerName);
                            counter = 5;
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard3"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard4", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", Score);
                            counter = 4;
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard3", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                            counter = 3;
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard2", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                            counter = 2;
                        }
                        else
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                            PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard1", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                            counter = 1;
                        }
                        ScoreToReach = Score;
                    }
                    else if (counter == 5)
                    {
                        if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard4"))
                        {
                            PlayerPrefs.SetInt("ScoreLeaderboard5", Score);
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard3"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard4", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", Score);
                            counter = 4;
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard3", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                            counter = 3;
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard2", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                            counter = 2;
                        }
                        else
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard4");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard4");
                            PlayerPrefs.SetString("NameLeaderboard5", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard5", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                            PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard1", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                            counter = 1;
                        }
                        ScoreToReach = Score;
                    }
                    else if (counter == 4)
                    {
                        if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard3"))
                        {
                            PlayerPrefs.SetInt("ScoreLeaderboard4", Score);
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard3", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                            counter = 3;
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard2", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                            counter = 2;
                        }
                        else
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard3");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard3");
                            PlayerPrefs.SetString("NameLeaderboard4", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard4", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                            PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard1", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                            counter = 1;
                        }
                        ScoreToReach = Score;
                    }
                    else if (counter == 3)
                    {
                        if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard2"))
                        {
                            PlayerPrefs.SetInt("ScoreLeaderboard3", Score);
                        }
                        else if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard2", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                            counter = 2;
                        }
                        else
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard2");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard2");
                            PlayerPrefs.SetString("NameLeaderboard3", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard3", tempScoreLeaderboard);
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                            PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard1", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                            counter = 1;
                        }
                        ScoreToReach = Score;
                    }
                    else if (counter == 2)
                    {
                        if (Score <= PlayerPrefs.GetInt("ScoreLeaderboard1"))
                        {
                            PlayerPrefs.SetInt("ScoreLeaderboard2", Score);
                        }
                        else
                        {
                            tempNameLeaderboard = PlayerPrefs.GetString("NameLeaderboard1");
                            tempScoreLeaderboard = PlayerPrefs.GetInt("ScoreLeaderboard1");
                            PlayerPrefs.SetString("NameLeaderboard2", tempNameLeaderboard);
                            PlayerPrefs.SetInt("ScoreLeaderboard2", tempScoreLeaderboard);
                            PlayerPrefs.SetString("NameLeaderboard1", playerName);
                            PlayerPrefs.SetInt("ScoreLeaderboard1", Score);
                            counter = 1;
                        }
                        ScoreToReach = Score;
                    }
                }
            }
        }
    }
}
