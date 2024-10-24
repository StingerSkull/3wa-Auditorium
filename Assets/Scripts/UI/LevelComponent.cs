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
    public Button levelButton;

    public void Initialize(LevelData data)
    {
        levelIcon.sprite = data.icon;
        levelNameLabel.text = data.levelName;
        levelButton.interactable = !data.unlock;

        /*
        levelButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(data.sceneName);
        });
        */

        levelButton.onClick.AddListener(() => {
            SceneManager.LoadScene(data.sceneName);
        });
    }
}
