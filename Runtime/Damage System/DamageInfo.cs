using UnityEngine;

public struct DamageInfo
{
    private float m_damage;
    private GameObject m_damager;
    private Vector3 m_direction;

    /// <summary>
    /// The amount of damge to be done.
    /// </summary>
    public float Damage => m_damage;

    /// <summary>
    /// The Game Object doing the damge.
    /// </summary>
    public GameObject Damager => m_damager;

    /// <summary>
    /// The Direction the damage was recived from.
    /// </summary>
    public Vector3 Direction => m_direction;

    public DamageInfo(float damage, GameObject damager, Vector3 direction)
    {
        m_damage = damage;
        m_damager = damager;
        m_direction = direction;
    }
}
