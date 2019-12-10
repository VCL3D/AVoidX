using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageRead : MonoBehaviour
{

    public List<int[,]> GetWalls()
    {
        DirectoryInfo GridsDirInfo = new DirectoryInfo(Application.streamingAssetsPath + "/Grids");
        FileInfo[] Allpngs = GridsDirInfo.GetFiles("*.png");
        List<int[,]> WallList = new List<int[,]>();
        int[,] temp = new int[40,50];

        int counter = 0;

        foreach (FileInfo file in Allpngs)
        {
            Color[] pix = GetPixelMatrix(file.Name, counter);

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


    public Color[] GetPixelMatrix(string sourceFile, int id)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(Application.streamingAssetsPath + "/Grids/" + sourceFile);
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

        Texture2D newim = GameObject.Find("ImageScale").GetComponent<ImageScale>().ImScale(myTexture2D);
        File.WriteAllBytes(Application.streamingAssetsPath + "/NormalizedGrids/Grid" + id.ToString() + ".png", newim.EncodeToPNG());
        Color[] pixls = newim.GetPixels();
        return pixls;
    }

}
