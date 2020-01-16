using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateiTweenPath : MonoBehaviour
{
    public GameObject iTweenPathCreator;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CreatePath(int[,] PathArray)
    {
        List<Vector3> PathNodes = new List<Vector3>();
        int counter = 0;
        for (int i=0; i<40; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                if (PathArray[i,j] == 1)
                {
                    counter++;
                    PathNodes.Add(new Vector3((float)(-4.8f + 0.24 * i), (float)(0.18f + 0.24 * j), transform.position.z - 0.5f));
                }
            }
        }
        iTweenPathCreator.GetComponent<iTweenPath>().SetNodeCount(counter);
        iTweenPathCreator.GetComponent<iTweenPath>().SetNodes(PathNodes);
    }
}
