using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Level", menuName = "Game/Level")]
public class LevelData : ScriptableObject
{
    public Sprite icon;
    public string sceneName;
    public string levelName;
    public bool unlock;

}
