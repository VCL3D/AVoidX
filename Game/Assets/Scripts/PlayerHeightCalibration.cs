using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeightCalibration : MonoBehaviour
{
    bool calibrated = false;
    float dt = 0.0f;
    float updateRate = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject.Find("PlayerStream").GetComponent<PlayerStream>().PlayerScale(new Vector3(0f, 0.8f, 0f), new Vector3(1f, 1f, 1f));
            calibrated = false;
        }

        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            if (GameObject.Find("PlayerStream").GetComponent<MeshCollider>().bounds.size.y != 0 && !calibrated)
            {
                GameObject.Find("PlayerStream").GetComponent<PlayerStream>().PlayerScale(new Vector3(0f, 1f, 0f) * (float)(8.4 / GameObject.Find("PlayerStream").GetComponent<MeshCollider>().bounds.size.y), new Vector3(1f, 1f, -1f) * (float) (10.5/ GameObject.Find("PlayerStream").GetComponent<MeshCollider>().bounds.size.y));
                GameObject.Find("PlayerStream").transform.eulerAngles = new Vector3(0f, PlayerPrefs.GetFloat("Calibration"), 0f);
                calibrated = true;
            }
            dt -= (float)(1.0 / updateRate);
        }
    }
}
