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

[UnityEngine.CreateAssetMenu(fileName = "StatVariable", menuName = "Variable/Stat Variable")]
public class StatVariable : VariableBase<Stat>
{
    public new float Value => variableValue.Value;

    public float Max => variableValue.Max;

    public void Add(float amount) => variableValue.Add(amount);

    public void ChangeMax(float amount) => variableValue.ChangeMax(amount);

    public void Remove(float amount) => variableValue.Remove(amount);

    public void ResetStat() => variableValue.ResetStat();

    #region Overrides of VariableBase<Stat>

    /// <inheritdoc />
    public override string ToString()
    {
        return variableValue.ToString();
    }

    #endregion
}