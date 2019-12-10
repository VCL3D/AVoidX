using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class framespersec : MonoBehaviour
{
    float frameCount = 0;
    float dt = 0.0f;
    float fps = 0.0f;
    float updateRate = 4.0f;  // 4 updates per sec.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= (float) (1.0 / updateRate);
        }
        GetComponent<TextMesh>().text = fps.ToString();
    }
}
