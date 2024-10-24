using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelComponent : MonoBehaviour
{
    public List<LevelData> levelDatas;
    public GameObject levelComponent;

    // Start is called before the first frame update
    void Start()
    {
        foreach (LevelData levelData in levelDatas)
        {
            Instantiate(levelComponent, transform).GetComponent<LevelComponent>().Initialize(levelData);
        }
    }

}
