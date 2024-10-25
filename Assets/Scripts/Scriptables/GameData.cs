using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "new GameData", menuName = "Game/GameData")]
public class GameData : ScriptableObject
{
    public int currentLevelIndex;
    public List<LevelData> levels;

    public void GoTolevel(int index)
    {
        currentLevelIndex = index;
        SceneManager.LoadScene(levels[currentLevelIndex].sceneName);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(levels[currentLevelIndex].sceneName);
    }
    public void LoadNextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(levels[currentLevelIndex].sceneName);
    }
}
