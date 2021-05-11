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


/// <summary>
/// Base Class for all scriptable objects variables to inherit from.
/// </summary>
public abstract class VariableBase<T> : ScriptableObject
{
    // #if UNITY_EDITOR
    // [Multiline] public string developerDescription = "";
    // #endif

    #region Overrides of Object

    /// <inheritdoc />
    public override string ToString()
    {
        return variableValue.ToString();
    }

    #endregion

    /// <summary>
    /// The <see cref="T"/> value of this variable.
    /// </summary>
    [SerializeField] protected T variableValue;

    /// <summary>
    /// The Value of this variable.
    /// </summary>
    public T Value => variableValue;

    /// <summary>
    /// Set <see cref="T"/> of this variable to the passed in <see cref="VariableBase{T}"/>.
    /// </summary>
    /// <param name="value">The variableValue to set this variable to.</param>
    public void SetValue(T value)
    {
        variableValue = value;
    }

    /// <summary>
    /// Set the <see cref="T"/> of this variable to be the same as the <see cref="T"/> of the passed in variable.
    /// </summary>
    /// <param name="value">The <see cref="VariableBase{T}"/> to set <see cref="variableValue"/>.</param>
    public void SetValue(VariableBase<T> value)
    {
        variableValue = value.variableValue;
    }
}