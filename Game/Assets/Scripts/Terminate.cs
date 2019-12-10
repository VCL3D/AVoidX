using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Terminate : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("StartScreen");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.GetComponent<GameController>().changeDebugBox();
        }
    }
}
