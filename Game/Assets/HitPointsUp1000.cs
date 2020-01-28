using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointsUp1000 : MonoBehaviour
{
    public float velocity = 10f;
    public float AppearTime = 1f;
    public float DisappearPoint = 0.8f;
    public float DisappearTime = 1f;
    float StartPoint;
    float appearpersec;
    float disappearpersec;
    float deceleration;
    float alpha;
    bool appeared = false;
    void Start()
    {
        StartPoint = transform.position.y;
        deceleration = Mathf.Pow(velocity, 2) / 16;
        appearpersec = 1 / AppearTime;
        disappearpersec = 1 / DisappearTime;
    }

    void Update()
    {
        if (alpha < 1 && !appeared)
        {
            alpha += appearpersec * Time.deltaTime;
        }
        else
        {
            appeared = true;
            if (transform.position.y > StartPoint + 8 * DisappearPoint)
            {
                alpha -= disappearpersec * Time.deltaTime;
            }
        }
        alpha = Mathf.Min(alpha, 1f);
        alpha = Mathf.Max(alpha, 0f);
        this.GetComponent<TextMesh>().color = new Color(0.41f, 1f, 0f, alpha);
        transform.Translate(0f, velocity * Time.deltaTime, 0f);
        velocity -= deceleration * Time.deltaTime;
    }
}
