using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageRead : MonoBehaviour
{
    public List<int[,]> GetCoins()
    {
        DirectoryInfo GridsDirInfo = new DirectoryInfo(Application.streamingAssetsPath + "/Coins");
        FileInfo[] Allpngs = GridsDirInfo.GetFiles("*.png");
        List<int[,]> CoinList = new List<int[,]>();
        int[,] temp = new int[6, 6];

        int counter = 0;

        foreach (FileInfo file in Allpngs)
        {
            Color[] pix = GetCoinPixelMatrix(file.Name, counter);

            int[,] CoinMask = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (pix[6 * j + i].grayscale > 0.95) CoinMask[i, j] = 1;
                    else CoinMask[i, j] = 0;
                    temp[i, j] = CoinMask[i, j];
                }
            }
            counter++;
            CoinList.Add(temp);
            temp = new int[6, 6];
        }
        return CoinList;
    }


    public List<int[,]> GetWalls()
    {
        DirectoryInfo GridsDirInfo = new DirectoryInfo(Application.streamingAssetsPath + "/Walls");
        FileInfo[] Allpngs = GridsDirInfo.GetFiles("*.png");
        List<int[,]> WallList = new List<int[,]>();
        int[,] temp = new int[40,50];

        int counter = 0;

        foreach (FileInfo file in Allpngs)
        {
            Color[] pix = GetWallPixelMatrix(file.Name, counter);

            int[,] WallMask = new int[40, 50];
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (pix[40*j+i].grayscale > 0.95) WallMask[i, j] = 1;
                    else WallMask[i, j] = 0;
                    temp[i, j] = WallMask[i, j];
                }
            }
            counter++;
            WallList.Add(temp);
            temp = new int[40, 50];
        }
        return WallList;
    }


    public Color[] GetWallPixelMatrix(string sourceFile, int id)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(Application.streamingAssetsPath + "/Walls/" + sourceFile);
        //Debug.Log(bytes.GetLength(0));
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(bytes);
        //Texture2D tex = Resources.Load("Grids/" + name) as Texture2D;
        // Create a temporary RenderTexture of the same size as the texture
        RenderTexture tmp = RenderTexture.GetTemporary(tex.width, tex.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
        // Blit the pixels on texture to the RenderTexture
        Graphics.Blit(tex, tmp);
        // Backup the currently set RenderTexture
        RenderTexture previous = RenderTexture.active;
        // Set the current RenderTexture to the temporary one we created
        RenderTexture.active = tmp;
        // Create a new readable Texture2D to copy the pixels to it
        Texture2D myTexture2D = new Texture2D(tex.width, tex.height);
        // Copy the pixels from the RenderTexture to the new Texture
        myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
        myTexture2D.Apply();
        // Reset the active RenderTexture
        RenderTexture.active = previous;
        // Release the temporary RenderTexture
        RenderTexture.ReleaseTemporary(tmp);
        // "myTexture2D" now has the same pixels from "texture" and it's readable.

        Texture2D newim = GameObject.Find("ImageScale").GetComponent<ImageScale>().WallScale(myTexture2D);
        File.WriteAllBytes(Application.streamingAssetsPath + "/NormalizedWalls/Wall" + id.ToString() + ".png", newim.EncodeToPNG());
        Color[] pixls = newim.GetPixels();
        return pixls;
    }

    public Color[] GetCoinPixelMatrix(string sourceFile, int id)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(Application.streamingAssetsPath + "/Coins/" + sourceFile);
        //Debug.Log(bytes.GetLength(0));
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(bytes);
        //Texture2D tex = Resources.Load("Grids/" + name) as Texture2D;
        // Create a temporary RenderTexture of the same size as the texture
        RenderTexture tmp = RenderTexture.GetTemporary(tex.width, tex.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
        // Blit the pixels on texture to the RenderTexture
        Graphics.Blit(tex, tmp);
        // Backup the currently set RenderTexture
        RenderTexture previous = RenderTexture.active;
        // Set the current RenderTexture to the temporary one we created
        RenderTexture.active = tmp;
        // Create a new readable Texture2D to copy the pixels to it
        Texture2D myTexture2D = new Texture2D(tex.width, tex.height);
        // Copy the pixels from the RenderTexture to the new Texture
        myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
        myTexture2D.Apply();
        // Reset the active RenderTexture
        RenderTexture.active = previous;
        // Release the temporary RenderTexture
        RenderTexture.ReleaseTemporary(tmp);
        // "myTexture2D" now has the same pixels from "texture" and it's readable.

        Texture2D newim = GameObject.Find("ImageScale").GetComponent<ImageScale>().CoinsScale(myTexture2D);
        File.WriteAllBytes(Application.streamingAssetsPath + "/NormalizedCoins/Coins" + id.ToString() + ".png", newim.EncodeToPNG());
        Color[] pixls = newim.GetPixels();
        return pixls;
    }

}
