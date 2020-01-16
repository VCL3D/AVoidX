using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyCountdown()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
