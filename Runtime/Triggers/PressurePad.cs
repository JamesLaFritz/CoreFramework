using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField, Tag] private string m_activationTag = "PressureActivator";
    [SerializeField] private float m_radius = 0.1f;
    [SerializeField] private UnityEvent m_activationEvent;

    private Vector3 m_position;
    private bool m_hasActivationObject;
    private Transform m_activationObjectTransform;

    private void Start()
    {
        m_position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ReSharper disable once PossibleNullReferenceException
        if (!other.CompareTag(m_activationTag))
            return;
        m_activationObjectTransform = other.transform;

        m_hasActivationObject = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // ReSharper disable once PossibleNullReferenceException
        if (!other.CompareTag(m_activationTag))
            return;

        m_hasActivationObject = false;
        m_activationObjectTransform = null;
    }

    private void Update()
    {
        if (!m_hasActivationObject) return;

        // when close enough to the center
        if (m_activationObjectTransform.position.x > m_position.x + m_radius ||
            m_activationObjectTransform.position.x > m_position.x - m_radius)
        {
            return;
        }

        m_hasActivationObject = false;

        // stop the object from moving
        Rigidbody body = m_activationObjectTransform.GetComponent<Rigidbody>();
        if (body != null)
        {
            body.isKinematic = true;
        }

        m_activationObjectTransform.position = m_position;
        m_activationObjectTransform.rotation = Quaternion.identity;
        m_activationObjectTransform = null;

        // trigger a Unity Event
        m_activationEvent?.Invoke();
    }
}