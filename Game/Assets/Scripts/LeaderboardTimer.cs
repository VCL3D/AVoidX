using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardTimer : MonoBehaviour
{
    public float updateRate = 1.0f;
    float dt = 0.0f;

    void Update()
    {
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            dt -= (float)(1.0 / updateRate);
        }
    }

    public bool getTriger()
    {
        if (dt > 0.95 / updateRate) return true;
        else return false;
    }
}
