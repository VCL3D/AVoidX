using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void NameField()
    {
        GameObject.Find("NameText").GetComponent<SubmitName>().enabled = true; 
    }

    public void Deselect()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("dialogBox");
        foreach (GameObject go in gos)
        {
            go.GetComponent<SubmitName>().enabled = false;
        }
    }

    public void TimeField()
    {
        GameObject.Find("TimeText").GetComponent<SubmitName>().enabled = true;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("dialogBox");
        foreach (GameObject go in gos)
        {
            if (go.name != "TimeText") go.GetComponent<SubmitName>().enabled = false;
        }
    }

    public void SpeedField()
    {
        GameObject.Find("SpeedText").GetComponent<SubmitName>().enabled = true;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("dialogBox");
        foreach (GameObject go in gos)
        {
           if (go.name != "SpeedText") go.GetComponent<SubmitName>().enabled = false;
        }
    }

    public void FreqField()
    {
        GameObject.Find("FrequencyText").GetComponent<SubmitName>().enabled = true;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("dialogBox");
        foreach (GameObject go in gos)
        {
            if (go.name != "FrequencyText") go.GetComponent<SubmitName>().enabled = false;
        }
    }

    public void CameraField()
    {
        GameObject.Find("CameraText").GetComponent<SubmitName>().enabled = true;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("dialogBox");
        foreach (GameObject go in gos)
        {
            if (go.name != "CameraText") go.GetComponent<SubmitName>().enabled = false;
        }
    }

    public void WallField()
    {
        GameObject.Find("WallText").GetComponent<SubmitName>().enabled = true;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("dialogBox");
        foreach (GameObject go in gos)
        {
            if (go.name != "WallText") go.GetComponent<SubmitName>().enabled = false;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_7");
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("Scene_8");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
