using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BakedWallGenerator32 : MonoBehaviour
{
    public GameObject Block;
    public GameObject WallCollection;
    List<int[,]> WallList = new List<int[,]>();
    public Material mat;

    void Start()
    {
        WallCollection = GameObject.Find("WallCollection");
        WallList = WallCollection.GetComponent<WallCollection32>().GetWalls(5, 32, 32);
        for (int i = 0; i < 5; i++)
        {
            InitiateWall(new Vector3(0, 0, 100 * i + 100), WallList.ElementAt(i));
        }
    }


    void Update()
    {

    }

    private void InitiateWall(Vector3 pos, int[,] Mask)
    {
        List<GameObject> FinalWallList = new List<GameObject>();
        List<CombineInstance> CombineWallList = new List<CombineInstance>();
        //GameObject[] Wall1 = new GameObject[20];
        GameObject Wall = new GameObject();
        Wall.name = "Wall";
        Wall.tag = "Wall";
        Wall.layer = 9;
        Wall.AddComponent<MeshFilter>();
        Wall.AddComponent<MeshRenderer>();
        Wall.GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        Wall.transform.position = new Vector3(0f, 0f, 0f);

        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                if (Mask[i, j] == 1)
                {
                    GameObject WallBlock = Instantiate(Block, new Vector3((float)(-4.8f + 0.3 * i), (float)(0.15f + 0.3 * j), 0f), Quaternion.identity) as GameObject;
                    WallBlock.layer = 9;
                    FinalWallList.Add(WallBlock);
                    WallBlock.transform.parent = Wall.transform;
                    WallBlock.name = ("Block");
                    WallBlock.tag = ("Block");
                }
            }
        }

        Wall.AddComponent<CombineMeshes>();
        Wall.GetComponent<CombineMeshes>().MeshCombiner();
        Wall.GetComponent<MeshRenderer>().material = mat;
        DestroyAllObjects("Block");
        Wall.transform.position = pos;
        Wall.AddComponent<WallMask>();
        Wall.GetComponent<WallMask>().SetMask(Mask);
        Wall.AddComponent<World>();
        Wall.AddComponent<Destroy>();
        Wall.AddComponent<DetectShadow32>();

    }

    void DestroyAllObjects(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
