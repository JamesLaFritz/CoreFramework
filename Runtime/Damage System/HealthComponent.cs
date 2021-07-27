using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    [Header("Health Data")]
    [SerializeField] private StatReference m_health;

    private bool m_isDead;

    public bool IsDead => m_isDead;

    private DamageInfo m_damageInfo;

    public DamageInfo damageInfo => m_damageInfo;

    [Header("Invulnerability Settings")] [SerializeField]
    private bool m_enableGodMode = false;

    [ReadOnlyAttribute] private bool m_isInvulnerable = false;

    [Space(10), SerializeField] private bool m_isInvulnerableAfterEnabled = false;
    [SerializeField] private bool m_isInvulnerableAfterDamage = false;

    [SerializeField] private float m_invulnerableDuration = 5.0f;
    [ReadOnlyAttribute] private float m_currentInvulnerableTimer = 0.0f;

    #region Implementation of IDamageable

    /// <inheritdoc />
    public void Hit(DamageInfo info)
    {
        if (m_isInvulnerable || m_enableGodMode || m_isDead)
        {
            m_damageInfo = new DamageInfo(0, null, Vector3.zero);
            return;
        }

        m_damageInfo = info;

        m_health.Remove(info.Damage);

        if (m_health.Value <= 0)
            m_isDead = true;
        else if (m_isInvulnerableAfterDamage)
            EnableInvulnerability();
    }
    
    #endregion
    
    #region Unity Events
    public void Awake()
    {
        m_health.ResetStat();
    }

    public void OnEnable()
    {
        m_isDead = m_health.Value > 0;
        
        /// After spawning, is invulnerable for a short time
        if (m_isInvulnerableAfterEnabled)
            EnableInvulnerability();
    }

    public void Update()
    {
        /// if it is invulnerable and the current timer is > 0,
        /// decrease and take it to 0. Once to 0, reset invulnerability.   
        if (m_isInvulnerable)
        {
            if (m_currentInvulnerableTimer > 0)
            {
                m_currentInvulnerableTimer -= Time.deltaTime;
            }
            else
            {
                m_currentInvulnerableTimer = 0;
                m_isInvulnerable = false;
            }
        }
    }
    
    #endregion

    /// <summary>
    /// Enable Invulnerability for a short time.
    /// </summary>
    public void EnableInvulnerability()
    {
        m_isInvulnerable = true;
        m_currentInvulnerableTimer = m_invulnerableDuration;
    }
}
