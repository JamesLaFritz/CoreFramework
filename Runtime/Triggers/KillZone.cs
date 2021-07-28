using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField, Tag] private string m_PlayerTag = "Player";

    [SerializeField] private BoolReference m_playerDead;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Assert(other != null, nameof(other) + " != null");
        if (!other.CompareTag(m_PlayerTag)) return;

        Debug.Assert(m_playerDead != null, nameof(m_playerDead) + " != null");
        m_playerDead.Value = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Assert(other != null, nameof(other) + " != null");
        if (!other.CompareTag(m_PlayerTag)) return;

        Debug.Assert(m_playerDead != null, nameof(m_playerDead) + " != null");
        m_playerDead.Value = true;
    }
}