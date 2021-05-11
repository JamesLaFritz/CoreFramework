#region Description

// 03-05-2021
// James LaFritz
// ----------------------------------------------------------------------------
// Based on
//
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

#endregion

using UnityEngine;


[CreateAssetMenu(fileName = "IntVariable", menuName = "Variable/Int")]
public class IntVariable : VariableBase<int>
{
    public void Add(int amount)
    {
        variableValue += amount;
    }
}