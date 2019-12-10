using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitName : MonoBehaviour
{
    string value;
    // Start is called before the first frame update
    void Start()
    {
        value = this.gameObject.GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (value.Length >0 )
            value = value.Remove(value.Length - 1);
        }
        else 
        value += Input.inputString;
        GetComponent<Text>().text = value;
    }
}
