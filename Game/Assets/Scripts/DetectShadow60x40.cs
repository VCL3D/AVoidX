using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShadow60x40 : MonoBehaviour
{
    RaycastHit hit;
    int hitsAllowed;
    int hits;
    bool check = false;

    void Start()
    {
        hitsAllowed = GameObject.Find("GameController").GetComponent<GameController>().GetHitsAllowed();
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.z) < 1 && !check)
        {
            hits = 0;
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (GetComponent<WallMask>().GetMask(i, j) == 1)
                        ShadowCheck(new Vector3((float)(-4.8f + 0.24 * i), (float)(0.18f + 0.24 * j), transform.position.z - 0.5f));
                }
            }
            if (hits > hitsAllowed)
            {
                GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().ScoreDown(500);
            }
            else
            {
                GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().ScoreUp(1000);
            }
            check = true;
        }
    }

    private void ShadowCheck(Vector3 pos)
    {
        if (Physics.Raycast(new Vector3(pos.x, pos.y, 5), Vector3.back, out hit, 20))
        {
            string str = hit.collider.tag;
            if (str == "Player")
            {
                hits += 1;
                if (GameObject.Find("GameController").GetComponent<GameController>().GetDebugBox())
                {
                    GameObject go = Instantiate(Resources.Load("debugBox"), hit.point, Quaternion.identity) as GameObject;
                    go.AddComponent<DebugDestroy>();
                    go.tag = "debugBox";
                    go.layer = 11;
                    go.name = "debugBox";
                }

            }
        }
    }

}
