using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// A simple cool down timer.
/// </summary>
[System.Serializable]
[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
public class CoolDownTimer
{
    private float m_coolDownTime;

    // ReSharper disable once InconsistentNaming
    [SerializeField] private float m_minCoolDownTime = 0.5f;

    // ReSharper disable once InconsistentNaming
    [SerializeField] private float m_maxCoolDownTime = 0.5f;

    public bool IsActive { get; private set; }

    [SerializeField] private FloatReference percentageCompleted;

    [SerializeField] private FloatReference coolDownTimeLeft;

    private float m_completeTime;

    private float m_startTime;

    public void OnDisabled()
    {
        IsActive = false;
    }

    public IEnumerator CoolDown()
    {
        IsActive = true;
        m_startTime = Time.time;
        m_coolDownTime = Random.Range(m_minCoolDownTime, m_maxCoolDownTime);
        m_completeTime = m_startTime + m_coolDownTime;

        Debug.Assert(percentageCompleted != null, nameof(percentageCompleted) + " != null");

        while (Time.time < m_completeTime)
        {
            // percentage completed 0 - 1 = current / maximum
            percentageCompleted.Value = math.min((Time.time - m_startTime) / m_coolDownTime, 1f);
            if (coolDownTimeLeft != null)
                coolDownTimeLeft.Value = math.max(m_completeTime - Time.time, 0f);
            yield return null;
        }

        percentageCompleted.Value = 1;

        IsActive = false;
    }
}
