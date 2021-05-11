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

[System.Serializable]
public class StatReference : VariableReference<StatVariable, Stat>
{
    public new float Value => useConstant ? constantValue.Value : variable.Value;

    public float Max
    {
        get => useConstant ? constantValue.Max : variable.Max;
        set
        {
            if (useConstant)
                constantValue.ChangeMax(value);
            else
            {
                Debug.Assert(variable != null, nameof(variable) + " != null");
                variable.ChangeMax(value);
            }
        }
    }

    public void Add(float amount)
    {
        if (useConstant)
            constantValue.Add(amount);
        else
            variable.Add(amount);
    }

    public void Remove(float amount)
    {
        if (useConstant)
            constantValue.Remove(amount);
        else
            variable.Remove(amount);
    }

    public void ResetStat()
    {
        if (useConstant)
            constantValue.ResetStat();
        else
            variable.ResetStat();
    }

    #region Overrides of Object

    /// <inheritdoc />
    public override string ToString() => useConstant ? constantValue.ToString() : variable.ToString();

    #endregion
}