using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevels
{
    private readonly Dictionary<LevelData, bool> _mapUnlockLevels = new();

    public bool this[LevelData key]
    {
        // returns value if exists
        get { return _mapUnlockLevels[key]; }

        // updates if exists, adds if doesn't exist
        set { _mapUnlockLevels[key] = value; }
    }

    public IDictionary<LevelData, bool> Get() 
    {  
        return _mapUnlockLevels; 
    }
}