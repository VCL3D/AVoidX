using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclopes : MonoBehaviour
{
    public float cyclopespeed;
    GameObject Area;

    // Start is called before the first frame update
    void Start()
    {
        Area = GameObject.Find("Area");
    }

    // Update is called once per frame
    void Update()
    {
        if (Area.transform.position.z >= 700)
        {
            transform.Translate(0f, 0f, cyclopespeed * Time.deltaTime);
        }
    }
}
