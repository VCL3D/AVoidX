using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomWallGenerator : MonoBehaviour
{
    public GameObject Block;
    List<int[,]> WallList = new List<int[,]>();
    public GameObject coin;
    List<int[,]> CoinList = new List<int[,]>();
    GameObject Gamespeed;

    public Material mat;
    private float generatespeed;
    private float cameraThres;
    System.Random rnd = new System.Random();
    int WallCounter;
    int CoinCounter;

    void Start()
    {
        WallList = this.gameObject.GetComponent<ImageRead>().GetWalls();
        CoinList = this.gameObject.GetComponent<ImageRead>().GetCoins();
        WallCounter = WallList.Count;
        CoinCounter = CoinList.Count;
        Gamespeed = GameObject.Find("Gamespeed");
        generatespeed = Gamespeed.GetComponent<Gamespeed>().GetGenerateSpeed();
        cameraThres = Gamespeed.GetComponent<Gamespeed>().GetCameraThres();
        StartCoroutine("CreateWalls");
    }

    void Update()
    {

    }

    private void InitiateWall(Vector3 pos, int[,] Mask)
    {
        List<GameObject> FinalWallList = new List<GameObject>();
        List<CombineInstance> CombineWallList = new List<CombineInstance>();
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
        Wall.AddComponent<DetectCollision>();
        Wall.AddComponent<DetectCameraMove>();
    }

    private void InitiateCoin(Vector3 pos, int[,] Mask)
    {
        GameObject Coins = new GameObject();
        Coins.transform.position = pos;
        Coins.name = ("Coins");
        Coins.tag = ("Coins");
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (Mask[i, j] == 0)
                {
                    GameObject Coin = Instantiate(coin, new Vector3((float)(-4f + 1.6 * i), (float)(1f + 1.7 * j), pos.z), Quaternion.identity) as GameObject;
                    Coin.layer = 9;
                    Coin.name = ("Coin");
                    Coin.tag = ("Coin");
                    Coin.transform.parent = Coins.transform;
                    //Coin.AddComponent<World>();
                    Coin.AddComponent<DetectCoinCollision>();
                    //Coin.AddComponent<DetectCameraMove>();
                }
            }
        }
        Coins.AddComponent<Destroy>();
        Coins.AddComponent<World>();

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
            int number = rnd.Next(0, 3);
            Debug.Log(number);
            if (number != 0)
            {
                number = rnd.Next(0, WallCounter - 1);
                InitiateWall(new Vector3(0, 0, 200), WallList.ElementAt(number));
            }
            else
            {
                number = rnd.Next(0, CoinCounter - 1);
                InitiateCoin(new Vector3(0, 0, 200), CoinList.ElementAt(number));
            }
            yield return new WaitForSeconds(8/generatespeed);
            generatespeed = Gamespeed.GetComponent<Gamespeed>().GetGenerateSpeed();
        }
    }

}
