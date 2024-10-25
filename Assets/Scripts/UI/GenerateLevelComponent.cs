using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelComponent : MonoBehaviour
{
    public GameData gameData;
    public GameObject levelComponent;

    // Start is called before the first frame update
    void Start()
    {
        foreach (LevelData levelData in gameData.levels)
        {
            Instantiate(levelComponent, transform).GetComponent<LevelComponent>().Initialize(levelData);
        }
    }

}
