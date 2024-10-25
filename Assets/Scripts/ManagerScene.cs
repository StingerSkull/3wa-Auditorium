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
    public TextMeshProUGUI indexText;

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
        indexText.text = GameData.indexGameData.index.ToString();
    }

    public void Pause()
    {
        pausePanel.SetActive(isPaused._value);
    }

    public void Win()
    {
        if (GameData.indexGameData.index < gameData.levels.Count - 1)
        {
            SetLevels.unlockLevels[gameData.levels[GameData.indexGameData.index + 1]] = true;
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
