using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HDWallGenerator : MonoBehaviour
{
    public GameObject Block;
    public GameObject WallCollection;
    List<int[,]> WallList = new List<int[,]>();

    void Start()
    {
        WallCollection = GameObject.Find("WallCollection");
        WallList = WallCollection.GetComponent<WallCollection>().GetWalls(5, 64, 64);
        for (int i = 0; i < 5; i++)
        {
            InitiateWall(new Vector3(0, 0, 100 * i + 100), WallList.ElementAt(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitiateWall(Vector3 pos, int[,] Mask)
    {
        List<GameObject[]> FinalWallList = new List<GameObject[]>();
        GameObject[] FinalWall = new GameObject[1024];
        GameObject Wall = new GameObject();
        Wall.transform.position = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < 64; i++)
        {
            for (int j = 0; j < 64; j++)
            {
                if (Mask[i, j] == 1)
                {
                    GameObject WallBlock = Instantiate(Block, new Vector3((float)(-4.8f + 0.15 * i), (float)(0.15f + 0.15 * j), 0f), Quaternion.identity) as GameObject;
                    WallBlock.transform.parent = Wall.transform;
                    WallBlock.layer = 9;
                    WallBlock.name = ("Block");

                }
            }
        }
        Wall.transform.position = pos;
        Wall.layer = 9;
        Wall.AddComponent<World>();
        Wall.AddComponent<Destroy>();
    }
}
