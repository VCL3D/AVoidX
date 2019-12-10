using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMask : MonoBehaviour
{
    int[,] mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMask(int[,] m)
    {
        mask = m;
    }

    public int GetMask(int i, int j)
    {
        return mask[i,j];
    }
}
