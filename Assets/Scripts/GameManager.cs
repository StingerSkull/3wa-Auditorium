using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeToWin = 1f;
    public GameObject winPanel;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject mouseManager;

    private GameObject[] musicBoxes;
    private float chrono;
    private int counter;
    private bool isPaused = false;
    private bool canPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(isPaused);
        winPanel.SetActive(false);
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
                winPanel.SetActive(true);
                mouseManager.SetActive(false);
                pauseButton.SetActive(false);
                canPaused = false;
            }
        }
        else
        {
            chrono = 0f;
        }
    }

    public void Pause()
    {
        if (canPaused)
        {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
            mouseManager.SetActive(!isPaused);

            if (isPaused)
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

    public void ChangeScene(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene(bool pause)
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if(pause) Pause();
        SceneManager.LoadScene(activeScene);
    }
}
