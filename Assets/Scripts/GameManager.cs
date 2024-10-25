using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeToWin = 1f;
    public GameObject mouseManager;
    public GameEvent winEvent;
    public FloatVariable winBarValue;
    public BoolVariable isPaused;

    private GameObject[] musicBoxes;
    private float chrono;
    private int counter;
    private bool canPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        isPaused._value = false;
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
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
            
            if (chrono >= timeToWin && canPaused)
            {
                winEvent.Trigger();
            }
        }
        else
        {
            chrono = 0f;
        }
        winBarValue._value = chrono / timeToWin;
    }

    public void Pause()
    {
        if (canPaused)
        {
            isPaused._value = !isPaused._value;
            mouseManager.SetActive(!isPaused._value);

            if (isPaused._value)
            {
                Time.timeScale = 0f;
                foreach (GameObject mBox in musicBoxes)
                {
                    mBox.GetComponent<AudioSource>().Pause();
                }
            }
            else
            {
                Time.timeScale = 1f;
                foreach (GameObject mBox in musicBoxes)
                {
                    mBox.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    public void Win()
    {
        canPaused = false;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene(bool pause)
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if(pause) Pause();
        SceneManager.LoadScene(activeScene);
    }
}
