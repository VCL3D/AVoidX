using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float worldspeed = 30;
    public float generatespeed = 30;
    public float CameraThres = 60;
    public int hitsAllowedPerWall = 5;
    public int RunSeconds = 120;
    public string playerName;
    bool debugBox = false;

    void Awake()
    {
        if (GameObject.Find("MenuController"))
        {
            GameObject MenuController = GameObject.Find("MenuController");
            if (MenuController.GetComponent<MenuController>().GetPlayerName() == "") MenuController.GetComponent<MenuController>().SetPlayerName("Guest");
            playerName = MenuController.GetComponent<MenuController>().GetPlayerName();
            if (MenuController.GetComponent<MenuController>().GetTime() != "") RunSeconds = int.Parse(MenuController.GetComponent<MenuController>().GetTime());
            if (MenuController.GetComponent<MenuController>().GetSpeed() != "") worldspeed = float.Parse(MenuController.GetComponent<MenuController>().GetSpeed());
            if (MenuController.GetComponent<MenuController>().GetFrequency() != "") generatespeed = float.Parse(MenuController.GetComponent<MenuController>().GetFrequency());
            if (MenuController.GetComponent<MenuController>().GetCameraThres() != "") CameraThres = float.Parse(MenuController.GetComponent<MenuController>().GetCameraThres());
            if (MenuController.GetComponent<MenuController>().GetSensitivity() != "") hitsAllowedPerWall = int.Parse(MenuController.GetComponent<MenuController>().GetSensitivity());
        }
        else 
        {
            playerName = "guest";
        }

        GameObject.Find("Gamespeed").GetComponent<Gamespeed>().SetWorldSpeed(worldspeed);
        GameObject.Find("Gamespeed").GetComponent<Gamespeed>().SetGenerateSpeed(generatespeed);
        GameObject.Find("Gamespeed").GetComponent<Gamespeed>().SetCameraThres(CameraThres);
        if (GameObject.Find("CountdownCounter")) GameObject.Find("CountdownCounter").GetComponent<Countdown>().SetTotalSeconds(RunSeconds);

    }

    public int GetHitsAllowed()
    {
        return hitsAllowedPerWall;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string val)
    {
        playerName = val;
    }

    public void changeDebugBox()
    {
        debugBox = !debugBox;
    }

    public bool GetDebugBox()
    {
        return debugBox;
    }
}
