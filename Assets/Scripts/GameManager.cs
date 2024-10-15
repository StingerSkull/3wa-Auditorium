using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float timeToWin = 1f;

    private GameObject[] musicBoxes;
    private float chrono;
    private int counter;

    public UnityEvent onWin = new();

    // Start is called before the first frame update
    void Start()
    {
        musicBoxes = GameObject.FindGameObjectsWithTag("MusicBox");
    }

    // Update is called once per frame
    void Update()
    {
        counter = 0;
        foreach (GameObject mBox in musicBoxes)
        {
            if (mBox.GetComponent<AudioSource>().volume >= 1)
            {
                counter++;
            }
        }

        if (counter >= musicBoxes.Length)
        {
            chrono += Time.deltaTime;
            if (chrono >= timeToWin)
            {
                Debug.Log("YOU WIN");
                onWin.Invoke();
            }
        }
        else
        {
            chrono = 0f;
        }
    }
}
