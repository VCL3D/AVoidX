using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private float worldspeed;

    // Start is called before the first frame update
    void Start()
    {
        worldspeed = GameObject.Find("Gamespeed").GetComponent<Gamespeed>().GetWorldSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, -worldspeed * Time.deltaTime);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
