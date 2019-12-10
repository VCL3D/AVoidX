using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Vector3 initialpos;
    private Vector3 playerpos;
    GameObject Player;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        initialpos = transform.position;
        Player = GameObject.Find("Player");
        playerpos = Player.transform.position;
        dir = (playerpos - initialpos).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += 300*dir*Time.deltaTime;
    }
}
