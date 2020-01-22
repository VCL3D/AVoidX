using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCoinCollision : MonoBehaviour
{
    RaycastHit hit;
    GameObject ScoreCounter;
    GameObject GameController;
    bool check = false;
    bool capture = false;

    void Start()
    {
        ScoreCounter = GameObject.Find("ScoreCounter");
        GameController = GameObject.Find("GameController");
    }

    
    void Update()
    {
        if (Mathf.Abs(transform.position.z) < 2)
        {
            CheckCollisions(transform.position);
        }
    }

    private void CheckCollisions(Vector3 pos)
    {
        ShadowCheck(pos, new Vector3(pos.x, pos.y, pos.z - 0.5f));
        ShadowCheck(pos, new Vector3(pos.x - 0.5f, pos.y, pos.z - 0.5f));
        ShadowCheck(pos, new Vector3(pos.x + 0.5f, pos.y, pos.z - 0.5f));
        ShadowCheck(pos, new Vector3(pos.x, pos.y - 0.5f, pos.z - 0.5f));
        ShadowCheck(pos, new Vector3(pos.x, pos.y + 0.5f, pos.z - 0.5f));
        if (capture && !check)
        {
            check = true;
            ScoreCounter.GetComponent<ScoreCounter>().ScoreUp(200);
            Destroy(this.gameObject);
            GameObject ParticleEffect = Instantiate(Resources.Load("Buff3"), new Vector3(pos.x, pos.y, 0.5f), Quaternion.identity) as GameObject;
            //GameObject ScoreUp = Instantiate(Resources.Load("ScoreUp200"), new Vector3(pos.x, pos.y - 1.5f, 1f), Quaternion.identity) as GameObject;
        }
    }

    private void ShadowCheck(Vector3 ParentPos, Vector3 pos)
    {
        if (Physics.Raycast(new Vector3(pos.x, pos.y, 10), Vector3.back, out hit, 20))
        {
            string str = hit.collider.tag;
            if (str == "Player")
            {
                capture = true;
                if (GameController.GetComponent<GameController>().GetDebugBox())
                {
                    GameObject go = Instantiate(Resources.Load("debugBox"), new Vector3(ParentPos.x, ParentPos.y, 1), Quaternion.identity) as GameObject;
                    go.AddComponent<DebugDestroy>();
                    go.tag = "debugBox";
                    go.layer = 11;
                    go.name = "debugBox";
                }
            }
        }
    }
}
