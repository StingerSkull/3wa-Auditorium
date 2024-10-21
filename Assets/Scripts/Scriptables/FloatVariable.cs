using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new " + nameof(FloatVariable), menuName = ScriptableUtils.VARIABLE_PATH + nameof(FloatVariable))]
public class FloatVariable : BaseVariable<float>
{
    public override void Move()
    {
        
    }
}
