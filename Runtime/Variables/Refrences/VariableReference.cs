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
public class VariableReference<T, TV> where T : VariableBase<TV>
{
    public bool useConstant = true;
    public TV constantValue;
    public T variable;

    public VariableReference() { }

    public VariableReference(TV value)
    {
        useConstant = true;
        constantValue = value;
    }

    // ReSharper disable once PossibleNullReferenceException
    public TV Value
    {
        get => useConstant ? constantValue : variable.Value;
        set
        {
            if (useConstant)
                constantValue = value;
            else
            {
                Debug.Assert(variable != null, nameof(variable) + " != null");
                variable.SetValue(value);
            }
        }
    }

    public static implicit operator TV(VariableReference<T, TV> reference)
    {
        // ReSharper disable once PossibleNullReferenceException
        return reference.Value;
    }
}