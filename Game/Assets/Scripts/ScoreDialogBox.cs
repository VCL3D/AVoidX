using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDialogBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "Your Score was " + GameObject.Find("MenuController").GetComponent<MenuController>().GetScore().ToString() + " pts!";
    }

}
