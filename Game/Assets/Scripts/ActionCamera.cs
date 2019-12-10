using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionCamera : MonoBehaviour
{
    List<GameObject> Walls = new List<GameObject>();
    float worldspeed;
    float cameraThres;

    // Start is called before the first frame update
    void Start()
    {
        worldspeed = GameObject.Find("Gamespeed").GetComponent<Gamespeed>().GetWorldSpeed();
        cameraThres = GameObject.Find("Gamespeed").GetComponent<Gamespeed>().GetCameraThres();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void CameraMove()
    {
        StartCoroutine(CameraFullMove());
    }

    public IEnumerator CameraFullMove()
    {
        StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(0f, 8f, -19f), (float) 0.4* 25 * cameraThres / (90 * worldspeed), true));
        yield return new WaitForSeconds((float) 3*25*cameraThres/(90*worldspeed));
        //StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(0f, 13f, -19f), 0.2f, false));
        this.gameObject.transform.position = new Vector3(0f, 13f, -19f);
        this.gameObject.transform.eulerAngles = new Vector3(12f, 0f, 0f);
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds, bool down)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        Vector3 startingRot = objectToMove.transform.eulerAngles;
        if (down)
        {
            while (elapsedTime < seconds)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                objectToMove.transform.eulerAngles = Vector3.Lerp(startingRot, new Vector3(0f, 0f, 0f), (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
            objectToMove.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            while (elapsedTime < seconds)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                objectToMove.transform.eulerAngles = Vector3.Lerp(startingRot, new Vector3(12f, 0f, 0f), (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
            objectToMove.transform.eulerAngles = new Vector3(12f, 0f, 0f);
        }
    }
}
