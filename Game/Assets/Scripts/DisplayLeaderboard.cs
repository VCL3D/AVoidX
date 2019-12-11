using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLeaderboard : MonoBehaviour
{
    string NameLeaderboard1;
    string NameLeaderboard2;
    string NameLeaderboard3;
    string NameLeaderboard4;
    string NameLeaderboard5;
    /*int ScoreLeaderboard1;
    int ScoreLeaderboard2;
    int ScoreLeaderboard3;
    int ScoreLeaderboard4;
    int ScoreLeaderboard5;*/

    /*float updateRate = 1.0f;
    float dt = 0.0f;*/

    void Start()
    {
        NameLeaderboard1 = PlayerPrefs.GetString("NameLeaderboard1");
        NameLeaderboard2 = PlayerPrefs.GetString("NameLeaderboard2");
        NameLeaderboard3 = PlayerPrefs.GetString("NameLeaderboard3");
        NameLeaderboard4 = PlayerPrefs.GetString("NameLeaderboard4");
        NameLeaderboard5 = PlayerPrefs.GetString("NameLeaderboard5");
        /*ScoreLeaderboard1 = PlayerPrefs.GetInt("ScoreLeaderboard1");
        ScoreLeaderboard2 = PlayerPrefs.GetInt("ScoreLeaderboard2");
        ScoreLeaderboard3 = PlayerPrefs.GetInt("ScoreLeaderboard3");
        ScoreLeaderboard4 = PlayerPrefs.GetInt("ScoreLeaderboard4");
        ScoreLeaderboard5 = PlayerPrefs.GetInt("ScoreLeaderboard5");
        this.gameObject.GetComponent<TextMesh>().text = "Leaderboard:\n1. " + NameLeaderboard1.ToString() + "   " + ScoreLeaderboard1.ToString() + "\n2. " + NameLeaderboard2.ToString() + "   " + ScoreLeaderboard2.ToString() + "\n3. " + NameLeaderboard3.ToString() + "   " + ScoreLeaderboard3.ToString() + "\n4. " + NameLeaderboard4.ToString() + "   " + ScoreLeaderboard4.ToString() + "\n5. " + NameLeaderboard5.ToString() + "   " + ScoreLeaderboard5.ToString();
*/    }

    void Update()
    {
        if (this.gameObject.GetComponentInParent<LeaderboardTimer>().getTriger())
        {
            NameLeaderboard1 = PlayerPrefs.GetString("NameLeaderboard1");
            NameLeaderboard2 = PlayerPrefs.GetString("NameLeaderboard2");
            NameLeaderboard3 = PlayerPrefs.GetString("NameLeaderboard3");
            NameLeaderboard4 = PlayerPrefs.GetString("NameLeaderboard4");
            NameLeaderboard5 = PlayerPrefs.GetString("NameLeaderboard5");
            this.gameObject.GetComponent<TextMesh>().text = "Leaderboard:\n1. " + NameLeaderboard1.ToString() + "\n2. " + NameLeaderboard2.ToString() + "\n3. " + NameLeaderboard3.ToString() + "\n4. " + NameLeaderboard4.ToString() + "\n5. " + NameLeaderboard5.ToString();
        }

        /* dt += Time.deltaTime;
         if (dt > 1.0 / updateRate)
         {
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
             this.gameObject.GetComponent<TextMesh>().text = "Leaderboard:\n1. " + NameLeaderboard1.ToString() + "   " + ScoreLeaderboard1.ToString() + "\n2. " + NameLeaderboard2.ToString() + "   " + ScoreLeaderboard2.ToString() + "\n3. " + NameLeaderboard3.ToString() + "   " + ScoreLeaderboard3.ToString() + "\n4. " + NameLeaderboard4.ToString() + "   " + ScoreLeaderboard4.ToString() + "\n5. " + NameLeaderboard5.ToString() + "   " + ScoreLeaderboard5.ToString();

             dt -= (float)(1.0 / updateRate);
         }*/
    }
}
