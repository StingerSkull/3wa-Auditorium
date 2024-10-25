using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "new GameData", menuName = "Game/GameData")]
public class GameData : ScriptableObject
{
    
    public List<LevelData> levels;

    public static IndexGameData indexGameData = new();

    public void GoTolevel(int index)
    {
        indexGameData.index = index;
        SceneManager.LoadScene(levels[indexGameData.index].sceneName);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(levels[indexGameData.index].sceneName);
    }
    public void LoadNextLevel()
    {
        indexGameData.index++;
        SceneManager.LoadScene(levels[indexGameData.index].sceneName);
    }
}
