using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserEffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LaserEffect()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject Laser = Instantiate(Resources.Load("Laser bombardment"), new Vector3 (0f, 5f, 0f), Quaternion.identity) as GameObject;
    }
}
