using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStream : MonoBehaviour
{
    private float playerspeed=100;
    private bool portalpass;
    GameObject ScoreCounter;
    GameObject Xaxis;
    float updateRate = 4.0f;
    float dt = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        //StartCoroutine("Calibration");
        StartCoroutine(ResetMeshCollider());
        Xaxis = new GameObject();
        Xaxis.transform.position = new Vector3(0f, 0f, 0f);
        portalpass = false;
        ScoreCounter = GameObject.Find("ScoreCounter");
    }

    // Update is called once per frame
    void Update()
    {
        /*if ((Input.GetAxis("Horizontal") > 0 && Xaxis.transform.position.x <= 3.7) || (Input.GetAxis("Horizontal") < 0 && Xaxis.transform.position.x >= -3.7))

            Xaxis.transform.position = new Vector3(playerspeed * Input.GetAxis("Horizontal") * Time.deltaTime, 3.3f, 0f);
        transform.position = new Vector3(Xaxis.transform.position.x, 3.3f, 0f);*/
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            if (!this.gameObject.GetComponent<MeshCollider>().enabled) StartCoroutine(ResetMeshCollider());
            GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().sharedMesh;
            dt -= (float)(1.0 / updateRate);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            //ScoreCounter.GetComponent<ScoreCounter>().ScoreDown(100);
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

    public void DisableMeshCollider()
    {
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
    }



    IEnumerator Calibration()
    {
        yield return new WaitForSeconds(4);
        transform.position = new Vector3(0f, 4.7f, 0f);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        transform.localScale = new Vector3(6f, 6f, 6f);
        yield break;
    }

    IEnumerator ResetMeshCollider()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<MeshCollider>().enabled = true;
    }

    public void PlayerScale(Vector3 pos, Vector3 scal) 
    {
        transform.position = pos;
        transform.localScale = scal;
    }

    /*public IEnumerator MeshRendReset()
    {
        float updateRate = 1.0f;
        float dt = 0.0f;
        while (true)
        {
            dt += Time.deltaTime;
            if (dt > 1.0 / updateRate)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = !this.gameObject.GetComponent<MeshRenderer>().enabled;
                dt -= (float)(1.0 / updateRate);
            }
        }
        
        Debug.Log("HIT1");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("HIT2");
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        yield break;
    }*/
}
