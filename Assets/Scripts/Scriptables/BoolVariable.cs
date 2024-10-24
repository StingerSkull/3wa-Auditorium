using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new " + nameof(BoolVariable), menuName = ScriptableUtils.VARIABLE_PATH + nameof(BoolVariable))]
public class BoolVariable : BaseVariable<bool>
{
    public override void Move()
    {

    }
}
