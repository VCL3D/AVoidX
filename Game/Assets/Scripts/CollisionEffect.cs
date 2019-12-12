using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    private bool m_EffectPlaying = false;

    private float m_StartTime;
    private float m_EffectDuration = 3.0f;
    private MeshRenderer m_Renderer;


    public void TriggerEffect()
    {
        m_EffectPlaying = true;
        m_StartTime = Time.time;
    }

    private void SetMaterialProperties()
    {
        float effectTime = Time.time - m_StartTime;

        float half_duration = m_EffectDuration / 2.0f;
        float time_freq = 2.0f / half_duration / 2.0f;

        if (effectTime > half_duration) { 
            time_freq = 2.0f * 4.0f / half_duration / 2.0f;
        }
        m_Renderer.material.SetColor("hit_color", new Color(0.8f, 0.2f, 0.2f, 1.0f));
        m_Renderer.material.SetFloat("hit_blend_factor", 0.5f);

        m_Renderer.material.SetFloat("hit_time_frequency", time_freq);
        m_Renderer.material.SetFloat("hit_time", effectTime);

    }

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_EffectPlaying)
        {
            if((Time.time - m_StartTime) > m_EffectDuration)
            {
                m_EffectPlaying = false;
                m_Renderer.material.SetFloat("hit_time", 0.0f);
            }
            else
            {
                SetMaterialProperties();
            }
        }
        else
        {
            m_Renderer.material.SetFloat("hit_time", 0.0f);
        }
    }
}
