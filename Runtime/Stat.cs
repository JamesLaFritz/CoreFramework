using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] private float currentValue;

    [SerializeField] private float maxValue;

    [SerializeField] private GameEvent valueChanged;
    [SerializeField] private GameEvent valueIncreased;
    [SerializeField] private GameEvent valueDecreased;

    public float Value => currentValue;

    public float Max => maxValue;

    public void Add(float amount)
    {
        currentValue = Math.Min(currentValue + amount, maxValue);
        RaiseChangeEvent();
        RaiseIncreaseEvent();
    }

    public void Remove(float amount)
    {
        currentValue = Math.Max(currentValue - amount, 0);
        RaiseChangeEvent();
        RaiseDecreaseEvent();
    }

    public void ResetStat()
    {
        currentValue = maxValue;
        RaiseChangeEvent();
        RaiseIncreaseEvent();
    }

    public void ChangeMax(float amount)
    {
        float amountToAdd = amount - maxValue;
        maxValue = amount;
        currentValue = Math.Min(currentValue + amountToAdd, maxValue);
        RaiseChangeEvent();
        if (amountToAdd > 0)
            RaiseIncreaseEvent();
        else if (amountToAdd < 0)
            RaiseDecreaseEvent();
    }

    private void RaiseChangeEvent()
    {
        if (valueChanged != null) valueChanged.Raise();
    }

    private void RaiseIncreaseEvent()
    {
        if (valueIncreased != null) valueIncreased.Raise();
    }

    private void RaiseDecreaseEvent()
    {
        if (valueDecreased != null) valueDecreased.Raise();
    }

    #region Overrides of Object

    /// <inheritdoc />
    public override string ToString()
    {
        return currentValue + "/" + maxValue;
    }

    #endregion
}
