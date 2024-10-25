using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComponent : MonoBehaviour
{
    public TextMeshProUGUI levelNameLabel;
    public Image levelIcon;
    public Sprite levelLock;
    public Button levelButton;
    public GameData gameData;

    public void Initialize(LevelData data)
    {
        if (SetLevels.unlockLevels[data])
        {
            levelIcon.sprite = data.icon;
        }
        else
        {
            levelIcon.sprite = levelLock;
        }
        
        levelNameLabel.text = data.levelName;
        levelButton.interactable = SetLevels.unlockLevels[data];

        /*
        levelButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(data.sceneName);
        });
        */

        levelButton.onClick.AddListener(() => {
            gameData.GoTolevel(gameData.levels.IndexOf(data));
        });
    }
}
