using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevels : MonoBehaviour
{
    public GameData gameData;
    public static UnlockLevels unlockLevels = new();

    // Start is called before the first frame update
    void Start()
    {
        if (unlockLevels.Get().Count == 0)
        {
            foreach (LevelData levelData in gameData.levels)
            {
                unlockLevels[levelData] = levelData.unlock;
            }
        }
    }
}
