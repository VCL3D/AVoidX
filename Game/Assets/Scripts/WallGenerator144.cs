using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WallGenerator144 : MonoBehaviour
{
    public GameObject Wall;
    public GameObject WallCollection;
 
    List<int[,]> WallList = new List<int[,]>();

    void Start()
    {
        WallCollection = GameObject.Find("WallCollection");
        WallList = WallCollection.GetComponent<WallCollection>().GetWalls(2,12,12);
        for (int i=0; i<2; i++)
        {
            InitiateWall(new Vector3(0, 0, 50*i + 100), WallList.ElementAt(i));
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitiateWall(Vector3 pos, int[,] Mask)
    {
        GameObject InitialWall = Instantiate(Wall, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
        InitialWall.name = "Wall";
        InitialWall.layer = 9;
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        GameObject myBlock = null;
        
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                Vector3 posit = new Vector3((float) (-4.4 + 0.8 * i), (float)(0.4 + 0.8 * j), 0f);
                foreach (GameObject go in blocks)
                {
                    go.layer = 9;
                    if (go.transform.position == posit)
                    {
                        myBlock = go;
                        break;
                    }
                }
                if (Mask[i,j] == 0) Destroy(myBlock);
            }
        }
        InitialWall.transform.position = pos;
        InitialWall.AddComponent<World>();
        InitialWall.AddComponent<Destroy>();
    }
}
