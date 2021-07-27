using UnityEngine;
using UnityEngine.Events;

public class RequiredCollectableActivateTrigger : ActivateOnTrigger
{
    [SerializeField] private UnityEvent errorEvent;

    [SerializeField] private IntReference m_collectableCount;

    [SerializeField] private int m_amountNeeded;

    #region Overrides of ActivateTrigger

    /// <inheritdoc />
    protected override void Activate()
    {
        if (m_collectableCount.Value >= m_amountNeeded)
        {
            base.Activate();
        }
        else
        {
            errorEvent?.Invoke();
        }
    }

    #endregion
}