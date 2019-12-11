using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    string playerName;
    string time = "120";
    string speed = "25";
    string frequency = "1";
    string cameraThres = "60";
    string sensitivity = "10";
    string score = "0";

    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("MenuController").Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            playerName = GameObject.Find("NameText").GetComponent<Text>().text;
        }

        if (SceneManager.GetActiveScene().name == "OptionsScreen")
        {
            time = GameObject.Find("TimeText").GetComponent<Text>().text;
            speed = GameObject.Find("SpeedText").GetComponent<Text>().text;
            frequency = GameObject.Find("FrequencyText").GetComponent<Text>().text;
            cameraThres = GameObject.Find("CameraText").GetComponent<Text>().text;
            sensitivity = GameObject.Find("WallText").GetComponent<Text>().text;

        }
        Debug.Log("worldspeed = " + speed);
        Debug.Log("generatespeed = " + frequency);
        Debug.Log("time = " + time);
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string val)
    {
        playerName = val;
    }

    public string GetTime()
    {
        return time;
    }

    public string GetSpeed()
    {
        return speed;
    }

    public string GetFrequency()
    {
        return frequency;
    }
    public string GetCameraThres()
    {
        return cameraThres;
    }
    public string GetSensitivity()
    {
        return sensitivity;
    }

    public string GetScore()
    {
        return score;
    }

    public void SetScore(string val)
    {
        score = val;
    }
}
