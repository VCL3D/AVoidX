using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    int counter;
    GameObject PlayerStream;
    GameObject CountdownCounter;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("CountdownCounter")) counter = GameObject.Find("CountdownCounter").GetComponent<Countdown>().GetCounter();
        else counter = 1;
        PlayerStream = GameObject.Find("PlayerStream");
        CountdownCounter = GameObject.Find("CountdownCounter");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -2)
        {
            if (this.gameObject.tag == "Wall" || this.gameObject.tag == "Coins")
            {
                PlayerStream.GetComponent<PlayerStream>().DisableMeshCollider();
                if (counter == 0)
                {
                    CountdownCounter.GetComponent<Countdown>().StartCountdown();
                    counter = 1;
                } 
            }
            Destroy(this.gameObject);
        }
    }
}
