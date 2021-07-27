using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected float m_coolDown = 0.0f;
    [SerializeField] protected bool m_isOneShot = false;
    [SerializeField] protected bool m_isActivated = false;
    [SerializeField] protected bool m_canUse = true;

    [SerializeField, Tag] private string m_interactorTag = "Player";

    private float m_lastUse = 0.0f;

    public void Interact()
    {
        if (!CanInteract())
            return;

        m_lastUse = Time.time;
        m_isActivated = true;

        OnInteract();
    }

    protected abstract void OnInteract();

    public bool CanInteract()
    {
        if (!m_canUse) return false;
        if (m_isOneShot && m_isActivated) return false;
        if (!IsCoolDownEnded()) return false;

        return true;
    }

    public bool IsCoolDownEnded()
    {
        return (Time.time - m_lastUse >= m_coolDown);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(m_interactorTag)) return;

        Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(m_interactorTag)) return;

        Interact();
    }
}
