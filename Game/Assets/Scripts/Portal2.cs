using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
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
        if (Player.GetComponent<Player>().GetPortalStatus())
        {
            if (Mathf.Abs(Area.transform.position.z - transform.position.z) <= 1)
            {
                Player.GetComponent<Player>().ChangePosx(transform.position.x);
                Area.GetComponent<Renderer>().enabled = true;
                Player.GetComponentInChildren<Renderer>().enabled = true;
                Player.GetComponent<Player>().PortalStatusFalse();
            }
        }
    }
}
