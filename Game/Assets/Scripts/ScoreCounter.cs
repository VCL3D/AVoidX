using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        GetComponent<TextMesh>().text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = Score.ToString();
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
}
