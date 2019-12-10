using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject fireball;
    GameObject Area;
    bool init = true;

    // Start is called before the first frame update
    void Start()
    {
        Area = GameObject.Find("Area");
    }

    // Update is called once per frame
    void Update()
    {
        if (Area.transform.position.z >= 700 && init)
        {
            StartCoroutine("DoCheck");
            init = false;
        }

        if (Area.transform.position.z >= transform.position.z)
        {
            StopCoroutine("DoCheck");
        }
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
                var go = Instantiate(fireball, transform.position, Quaternion.identity) as GameObject;
                go.AddComponent<Fire>();
                yield return new WaitForSeconds(1.5f);

        }
    }
}
