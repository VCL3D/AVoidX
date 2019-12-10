using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = GameObject.Find("MenuController").GetComponent<MenuController>().GetPlayerName().ToString() + ",";
    }

}
