using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    RaycastHit hit;
    int hitsAllowed;
    int hits;
    bool check = false;
    GameObject ScoreCounter;
    GameObject PlayerStream;
    GameObject GameController;
    GameObject ParticlePath;
    int[,] CollisionArray;
    GameObject iTweenPathCreator;

    void Start()
    {
        hitsAllowed = GameObject.Find("GameController").GetComponent<GameController>().GetHitsAllowed();
        ScoreCounter = GameObject.Find("ScoreCounter");
        PlayerStream = GameObject.Find("PlayerStream");
        GameController = GameObject.Find("GameController");
        iTweenPathCreator = GameObject.Find("iTweenPathCreator");
        CollisionArray = new int[40, 50];
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
                        ShadowCheck(i,j, new Vector3((float)(-4.8f + 0.24 * i), (float)(0.18f + 0.24 * j), transform.position.z - 0.5f));
                }
            }
            if (hits != 0)
            {
                iTweenPathCreator.GetComponent<iTweenPath>().SetPath(CollisionArray);
                GameObject ParticleEffect = Instantiate(Resources.Load("Buff"), iTweenPathCreator.GetComponent<iTweenPath>().GetFirstNode(), Quaternion.identity) as GameObject;
                //ParticleEffect.AddComponent<FollowPath>();
            }

            if (hits == 0)
            {
                ScoreCounter.GetComponent<ScoreCounter>().ScoreUp(1000);
                GameObject ParticleEffect = Instantiate(Resources.Load("PurpleBuff"), PlayerStream.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity) as GameObject;
                GameObject ScoreUp = Instantiate(Resources.Load("ScoreUp"), PlayerStream.transform.position + new Vector3(0f, 3.5f, 1f), Quaternion.identity) as GameObject;
            }
            else if(hits < hitsAllowed)
            {
                ScoreCounter.GetComponent<ScoreCounter>().ScoreUp((int)((float)1000 * ((float)hitsAllowed - (float)hits) / (float)hitsAllowed));
                GameObject ScoreDown = Instantiate(Resources.Load("ScoreDown"), PlayerStream.transform.position + new Vector3(0f, 3.5f, 1f), Quaternion.identity) as GameObject;
                ScoreDown.GetComponent<TextMesh>().text = (-((int)((float)1000 * ((float)hitsAllowed - (float)hits) / (float)hitsAllowed))).ToString();
            }

            /*else if(hits < 2*hitsAllowed)
            {
                PlayerStream.GetComponent<CollisionEffect>().TriggerEffect();
                ScoreCounter.GetComponent<ScoreCounter>().ScoreDown(500);
            }*/

            else if (hits < 3 * hitsAllowed)
            {
                PlayerStream.GetComponent<CollisionEffect>().TriggerEffect();
                ScoreCounter.GetComponent<ScoreCounter>().ScoreDown((int)((float)1000 * (((float)hits - (float)(hitsAllowed))/ (float)(2 * hitsAllowed))));
                GameObject ScoreDown = Instantiate(Resources.Load("ScoreDown"), PlayerStream.transform.position + new Vector3(0f, 3.5f, 1f), Quaternion.identity) as GameObject;
                ScoreDown.GetComponent<TextMesh>().text = (-(int)((float)1000 * (((float)hits - (float)(hitsAllowed)) / (float)(2 * hitsAllowed)))).ToString();
            }
            else 
            {
                PlayerStream.GetComponent<CollisionEffect>().TriggerEffect();
                ScoreCounter.GetComponent<ScoreCounter>().ScoreDown(1000);
                GameObject ScoreDown = Instantiate(Resources.Load("ScoreDown"), PlayerStream.transform.position + new Vector3(0f, 3.5f, 1f), Quaternion.identity) as GameObject;
            }
            check = true;
        }
    }

    private void ShadowCheck(int i, int j, Vector3 pos)
    {
        if (Physics.Raycast(new Vector3(pos.x, pos.y, 10), Vector3.back, out hit, 20))
        {
            string str = hit.collider.tag;
            if (str == "Player")
            {
                hits += 1;
                CollisionArray[i, j] = 1;
                if (GameController.GetComponent<GameController>().GetDebugBox())
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
