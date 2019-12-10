using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamespeed : MonoBehaviour
{
    private float worldspeed;
    private float generatespeed;
    private float CameraThres;

    private void Start()
    {
        
    }

    public void SetWorldSpeed(float val)
    {
        worldspeed = val;
    }

    public float GetWorldSpeed()
    {
        return worldspeed;
    }

    public void SetGenerateSpeed(float val)
    {
        generatespeed = val;
    }

    public float GetGenerateSpeed()
    {
        return generatespeed;
    }
    public void SetCameraThres(float val)
    {
        CameraThres = val;
    }

    public float GetCameraThres()
    {
        return CameraThres;
    }
}
