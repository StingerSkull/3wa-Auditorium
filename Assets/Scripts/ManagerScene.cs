using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScene : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject nextLevelBtn;
    public GameObject winBar;

    public BoolVariable isPaused;
    public FloatVariable winBarValue;
    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(isPaused._value);
        winPanel.SetActive(false);
    }
    void Update()
    {
        winBar.GetComponent<Image>().fillAmount = winBarValue._value;
    }

    public void Pause()
    {
        pausePanel.SetActive(isPaused._value);
    }

    public void Win()
    {
        if (gameData.currentLevelIndex < gameData.levels.Count - 1)
        {
            gameData.levels[gameData.currentLevelIndex + 1].unlock = true;
        }
        else
        {
            nextLevelBtn.SetActive(false);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
