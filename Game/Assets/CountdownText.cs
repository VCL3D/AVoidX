using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownText : MonoBehaviour
{
    public float AppearOverTime = 0.2f;
    float alpha = 0f;
    bool AppearTime = false;
    bool CoroutineRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AppearTime && !CoroutineRunning)
        {
            CoroutineRunning = true;
            StartCoroutine(Appear());
        }
    }

    public void InitiateAppear()
    {
        AppearTime = true;
    }

    IEnumerator Appear()
    {
        AppearTime = false;
        Debug.Log("AppearTime!");
        float elapsed = 0.0f;
        while (alpha < 1f)
        {
            alpha = Mathf.Lerp(0f, 1f, elapsed/AppearOverTime);
            Debug.Log(alpha);
            alpha = Mathf.Min(alpha, 1f);
            elapsed += Time.deltaTime;
            GetComponent<TextMesh>().color = new Color(1f, 0.89f, 0.11f, Mathf.Min(alpha, 1f));
        }
        alpha = 0;
        CoroutineRunning = false;
        yield break;
    }

}
