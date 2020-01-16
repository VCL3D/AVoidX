using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicCameraCalibration : MonoBehaviour
{
    public Camera OrthographicCamera;
    public GameObject OrthographicBackground;
    public Material OrthographicBackgroundMat;
    void Awake()
    {
        if (Camera.main.aspect >= 1.7)
        {
            OrthographicCamera.orthographicSize = 8;
            OrthographicBackground.transform.localScale = new Vector3(1.44f, 1f, 1.54f);
            OrthographicBackgroundMat.mainTextureScale = new Vector2(0.53f, 1f);
            OrthographicBackgroundMat.mainTextureOffset = new Vector2(0.23f, 0f);
        }
        else
        {
            OrthographicCamera.orthographicSize = 8;
            OrthographicBackground.transform.localScale = new Vector3(1.3f, 1f, 1.55f);
            OrthographicBackgroundMat.mainTextureScale = new Vector2(0.475f, 1f);
            OrthographicBackgroundMat.mainTextureOffset = new Vector2(0.257f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
