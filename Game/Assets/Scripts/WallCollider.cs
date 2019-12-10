using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    GameObject ScoreCounter;
    /*SkinnedMeshRenderer meshRenderer;
    MeshCollider mcollider;
    private float time = 0;*/

    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter = GameObject.Find("ScoreCounter");
        /*
        meshRenderer = this.gameObject.GetComponent<SkinnedMeshRenderer>();
        mcollider = this.gameObject.GetComponent<MeshCollider>();
        */
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.tag == "Wall")
        {
            Debug.Log("WallCollision");
            ScoreCounter.GetComponent<ScoreCounter>().ScoreDown(100);
            
        }
    }
    /*
    public void UpdateCollider()
    {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        mcollider.sharedMesh = null;
        mcollider.sharedMesh = colliderMesh;
    }
    */
}
