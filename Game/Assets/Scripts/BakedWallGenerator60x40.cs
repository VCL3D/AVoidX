using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BakedWallGenerator60x40 : MonoBehaviour
{
    public GameObject Block;
    public GameObject WallCollection;
    List<int[,]> WallList = new List<int[,]>();
    public Material mat;
    private float generatespeed;

    void Start()
    {
        WallCollection = GameObject.Find("WallCollection");
        WallList = WallCollection.GetComponent<WallCollection60x40>().GetWalls(40, 50);
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

        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                if (Mask[i, j] == 1)
                {
                    GameObject WallBlock = Instantiate(Block, new Vector3((float)(-4.8f + 0.24 * i), (float)(0.18f + 0.24 * j), 0f), Quaternion.identity) as GameObject;
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
        Wall.AddComponent<DetectShadow60x40>();
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
                Debug.Log(generatespeed);
                InitiateWall(new Vector3(0, 0, 200 / generatespeed * i + 200 / generatespeed), WallList.ElementAt(i));
            }
            yield return new WaitForSeconds(40 / generatespeed);
        }
    }

}
