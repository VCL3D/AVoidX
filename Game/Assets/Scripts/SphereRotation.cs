using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    float cameraThres;
    float worldspeed;
    bool CameraMove = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraThres = GameObject.Find("Gamespeed").GetComponent<Gamespeed>().GetCameraThres();
        worldspeed = GameObject.Find("Gamespeed").GetComponent<Gamespeed>().GetWorldSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraMove)
        {
            CameraMove = false;
            StartCoroutine(CameraFullMove());
        }
    }

    /*public void CameraMove()
    {
        StartCoroutine(CameraFullMove());
    }*/

    public IEnumerator CameraFullMove()
    {
        //StartCoroutine(MoveOverSeconds(this.gameObject, (float) cameraThres / (2 * worldspeed), true));
        StartCoroutine(MoveOverSeconds(this.gameObject, 2f, true));
        yield return new WaitForSeconds((float) cameraThres / worldspeed);
        StartCoroutine(MoveOverSeconds(this.gameObject, 1f, false));
        //StartCoroutine(MoveOverSeconds(this.gameObject, (float) cameraThres / (5 * worldspeed), false));
        //this.gameObject.transform.position = new Vector3(0f, 8f, 0f);
        //this.gameObject.transform.eulerAngles = new Vector3(20f, 0f, 0f);
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, float seconds, bool down)
    {
        float elapsedTime = 0;
        Vector3 startingRot = objectToMove.transform.eulerAngles;
        //Vector3 startingPos = objectToMove.transform.position;
        if (down)
        {
            while (elapsedTime < seconds)
            {
                objectToMove.transform.eulerAngles = Vector3.Lerp(startingRot, new Vector3(0f, 0f, 0f), (elapsedTime / seconds));
                //objectToMove.transform.position = Vector3.Lerp(startingPos, new Vector3(0f, 8f, 4f), (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //objectToMove.transform.position = new Vector3(0f, 8f, 4f);
        }
        else
        {
            while (elapsedTime < seconds)
            {
                objectToMove.transform.eulerAngles = Vector3.Lerp(startingRot, new Vector3(15f, 0f, 0f), (elapsedTime / seconds));
                //objectToMove.transform.position = Vector3.Lerp(startingPos, new Vector3(0f, 8f, 0f), (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.eulerAngles = new Vector3(15f, 0f, 0f);
            //objectToMove.transform.position = new Vector3(0f, 8f, 0f);
        }
    }

    public void SetCameraMove(bool val)
    {
        CameraMove = val;
    }

    public void SetSphereWorldSpeed(float val)
    {
        worldspeed = val;
    }
    public void SetSphereCameraThres(int val)
    {
        cameraThres = val;
    }
}
