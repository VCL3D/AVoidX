using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bouncespeed;
    public float bouncelevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, bouncelevel*Mathf.Sin(bouncespeed*2*Mathf.PI), 0f);
    }
}
