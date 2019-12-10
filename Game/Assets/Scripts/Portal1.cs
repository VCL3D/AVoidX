using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    GameObject Player;
    GameObject Area;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Area = GameObject.Find("Area");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Area.transform.position.z - transform.position.z) <= 1) 
        {
            if (Mathf.Abs(Player.transform.position.x - transform.position.x) <= 1)
            {
                Player.GetComponent<Player>().PortalStatusTrue();
                Area.GetComponent<Renderer>().enabled = false;
                Player.GetComponentInChildren<Renderer>().enabled = false;
            }
        }
    }
}
