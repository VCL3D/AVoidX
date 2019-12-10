using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoinGenerator : MonoBehaviour
{
    public GameObject Coin;
    public GameObject CoinCollection;

    List<int[,]> CoinList = new List<int[,]>();

    void Start()
    {
        CoinCollection = GameObject.Find("CoinCollection");
        CoinList = CoinCollection.GetComponent<CoinCollection>().GetCoins(3, 16, 16);
        for (int i = 0; i < 3; i++)
        {
            InitiateCoins(new Vector3(0, 0, 100 * i + 150), CoinList.ElementAt(i));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitiateCoins(Vector3 pos, int[,] Mask)
    {
        GameObject InitialWall = Instantiate(Coin, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
        InitialWall.name = "Coins";
        InitialWall.layer = 9;
        GameObject[] Coins = GameObject.FindGameObjectsWithTag("Coin");
        GameObject myBlock = null;

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                Vector3 posit = new Vector3((float)(-4.5 + 0.6 * i), (float)(0.3 + 0.6 * j), 0f);
                foreach (GameObject go in Coins)
                {
                    go.layer = 9;
                    if (go.transform.position == posit)
                    {
                        myBlock = go;
                        break;
                    }
                }
                if (Mask[i, j] == 1) Destroy(myBlock);
            }
        }
        InitialWall.transform.position = pos;
        InitialWall.AddComponent<World>();
        InitialWall.AddComponent<Destroy>();
    }
}
