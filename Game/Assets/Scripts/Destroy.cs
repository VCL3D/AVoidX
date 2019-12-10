using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("CountdownCounter")) counter = GameObject.Find("CountdownCounter").GetComponent<Countdown>().GetCounter();
        else counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -2)
        {
            if (this.gameObject.tag == "Wall")
            {
                GameObject.Find("PlayerStream").GetComponent<PlayerStream>().DisableMeshCollider();
                if (counter == 0)
                {
                    GameObject.Find("CountdownCounter").GetComponent<Countdown>().WallCollision();
                    counter = 1;
                } 
            }
            Destroy(this.gameObject);
        }
    }
}
