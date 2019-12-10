using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCameraMove : MonoBehaviour
{
    bool check = false;
    float CameraThres;
    // Start is called before the first frame update
    void Awake()
    {
        CameraThres = GameObject.Find("Gamespeed").GetComponent<Gamespeed>().GetCameraThres(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < CameraThres && transform.position.z>0 && !check)
        {
            check = true;
            StartCoroutine(GameObject.Find("Sphere").GetComponent<SphereRotation>().CameraFullMove());
        }
    }
}
