using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BakedWallGenerator : MonoBehaviour
{
    public GameObject Block;
    public GameObject WallCollection;
    List<int[,]> WallList = new List<int[,]>();
    List<GameObject> Walls = new List<GameObject>();
    public Material mat;
    private float generatespeed;


    void Start()
    {
        WallCollection = GameObject.Find("WallCollection");
        WallList = WallCollection.GetComponent<WallCollection>().GetWalls(5, 64, 64);
        generatespeed = GameObject.Find("Gamespeed").GetComponent<Gamespeed>().GetGenerateSpeed();
        StartCoroutine("CreateWalls");
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

        for (int i = 0; i < 64; i++)
        {
            for (int j = 0; j < 64; j++)
            {
                if (Mask[i, j] == 1)
                {
                    GameObject WallBlock = Instantiate(Block, new Vector3((float)(-4.8f + 0.15 * i), (float)(0.15f + 0.15 * j), 0f), Quaternion.identity) as GameObject;
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
        Wall.AddComponent<DetectShadow>();
        Wall.AddComponent<DetectCameraMove>();
    }

    void DestroyAllObjects(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

    IEnumerator CreateWalls()
    {
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                InitiateWall(new Vector3(0, 0, 100 / generatespeed * i + 200 / generatespeed), WallList.ElementAt(i));
            }
            yield return new WaitForSeconds(26 / generatespeed);
        }
    }

    public List<GameObject> GetWalls()
    {
        return Walls;
    }
}
