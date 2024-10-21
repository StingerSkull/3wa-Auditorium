using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ScriptableVaraible", menuName = "Variable", order = 0)]
public class ScriptableVariable : ScriptableObject
{
    public int hp;
    public string playerName;
    //name reserve

    public void Test()
    {
        Debug.Log($"je suis {playerName} et j'ai {hp} point(s) de vie");
    }
}
