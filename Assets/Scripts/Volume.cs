using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [Header("Color")]
    public Color activeBarColor;
    public Color inactiveBarColor;

    [Header("Volume")]
    public float volumeIncrement;
    public float decayRate;
    public float decayTime;

    public SpriteRenderer[] bars;

    private int numberBarVolume = 0;
    private AudioSource m_AudioSource;
    //private SpriteRenderer[] bars;
    private float chrono;


    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = 0f;
        //bars = gameObject.GetComponentsInChildren<SpriteRenderer>();
        //PAS SUR DE L'ORDRE!!!!!!!!!!!!

        foreach (SpriteRenderer bar in bars)
        {
            bar.color = inactiveBarColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        chrono += Time.deltaTime;
        if (chrono >= decayTime)
        {
            m_AudioSource.volume -= Mathf.Min(m_AudioSource.volume, decayRate * Time.deltaTime);
        }

        numberBarVolume = 0;
        foreach (SpriteRenderer bar in bars) {
            if (m_AudioSource.volume <= (float)numberBarVolume/bars.Length)
            {
                bar.color = inactiveBarColor;
            }
            else
            {
                bar.color = activeBarColor;
            }
            numberBarVolume++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_AudioSource.volume += volumeIncrement;
        chrono = 0f;
    }
}
