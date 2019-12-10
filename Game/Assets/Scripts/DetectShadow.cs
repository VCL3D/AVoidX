using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShadow : MonoBehaviour
{
    private RaycastHit hit;

    void Update()
    {
        if (Mathf.Abs(transform.position.z) < 1)
        for (int i = 0; i < 64; i++)
        {
            for (int j = 0; j < 64; j++)
            {
                if (GetComponent<WallMask>().GetMask(i,j) == 1)
                    ShadowCheck(new Vector3((float)(-4.8f + 0.15 * i), (float)(0.15f + 0.15 * j), transform.position.z- 0.5f));
            }
        }
    }

    private void ShadowCheck(Vector3 pos)
    {
        if (Physics.Raycast(new Vector3(pos.x, pos.y, 5), Vector3.back, out hit, 20))
        {
            string str = hit.collider.tag;
            if (str == "Player")
            {
                GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().ScoreDown(100);
                Debug.Log("HIT!");
                GameObject go = Instantiate(Resources.Load("debugBox"), hit.point, Quaternion.identity) as GameObject;
                go.AddComponent<DebugDestroy>();
                go.tag = "debugBox";
                go.layer = 11;
                go.name = "debugBox";
            }
                
        }
    }
}
