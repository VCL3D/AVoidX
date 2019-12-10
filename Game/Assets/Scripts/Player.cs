using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerspeed;
    private bool portalpass;
    GameObject ScoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        portalpass=false;
        ScoreCounter = GameObject.Find("ScoreCounter");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal")>0 && transform.position.x <= 3.7) || (Input.GetAxis("Horizontal")<0 && transform.position.x >= -3.7))
            transform.Translate(playerspeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            ScoreCounter.GetComponent<ScoreCounter>().ScoreDown(100);
            Debug.Log("Collision");
        }
    }

    public float GetSpeed() 
    {
        return playerspeed;
    }

    public void ChangePosx(float val)
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(val, pos.y, pos.z);
    }

    public bool GetPortalStatus()
    {
        return portalpass;
    }

    public void PortalStatusFalse()
    {
        portalpass = false;
    }

    public void PortalStatusTrue()
    {
        portalpass = true;
    }
}
