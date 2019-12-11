using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamespeed : MonoBehaviour
{
    private float worldspeed;
    private float initialWorldspeed;
    private float generatespeed;
    private float initialGeneratespeed;
    private float CameraThres;
    private float initialCameraThres;
    float increment = 0;
    float updateRate = 1.0f;
    float dt = 0.0f;


    private void Start()
    {
        initialWorldspeed = worldspeed;
        initialGeneratespeed = generatespeed;
        initialCameraThres = CameraThres;
    }

    public void Update()
    {
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            if(GameObject.Find("CountdownCounter"))
            increment = ((float) GameObject.Find("CountdownCounter").GetComponent<Countdown>().TotalTime() - (float) GameObject.Find("CountdownCounter").GetComponent<Countdown>().RemainingTime()) / (float) GameObject.Find("CountdownCounter").GetComponent<Countdown>().TotalTime();
            worldspeed = initialWorldspeed * (1 + (float)0.56* increment);
            generatespeed = initialGeneratespeed * (1 + (float) 0.56 * increment);
            CameraThres = (int) (initialCameraThres * (1 + 0.55 * increment));
            GameObject.Find("Sphere").GetComponent<SphereRotation>().SetSphereWorldSpeed(worldspeed);
            GameObject.Find("Sphere").GetComponent<SphereRotation>().SetSphereCameraThres((int)CameraThres);
            
            dt -= (float)(1.0 / updateRate);
        }
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
