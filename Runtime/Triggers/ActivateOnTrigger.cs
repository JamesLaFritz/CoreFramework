using UnityEngine;
using UnityEngine.Events;

public class ActivateOnTrigger : MonoBehaviour
{
    [SerializeField, Tag] private string m_playerTag = "Player";

    private bool m_isCollidingWithPlayer;

    [SerializeField] protected UnityEvent activateEvent;
    

#if ENABLE_LEGACY_INPUT_MANAGER
    [SerializeField] private string m_activateInput = "Fire1";

    private void Update()
    {
        if (Input.GetButtonDown(m_activateInput))
        {
            Activate();
        }
    }
#elif ENABLE_INPUT_SYSTEM
    [SerializeField] private UnityEngine.InputSystem.InputAction m_activateInput;

    private void Awake()
    {
        m_activateInput.performed += ctx => Activate();
    }

    void OnEnable()
    {
        m_activateInput.Enable();
    }

    void OnDisable()
    {
        m_activateInput.Disable();
    }
#endif

    private void OnTriggerEnter(Collider other)
    {
        Debug.Assert(other != null, nameof(other) + " != null");
        if (!other.CompareTag(m_playerTag)) return;

        m_isCollidingWithPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Assert(other != null, nameof(other) + " != null");
        if (!other.CompareTag(m_playerTag)) return;

        m_isCollidingWithPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Assert(other != null, nameof(other) + " != null");
        if (!other.CompareTag(m_playerTag)) return;

        m_isCollidingWithPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Assert(other != null, nameof(other) + " != null");
        if (!other.CompareTag(m_playerTag)) return;

        m_isCollidingWithPlayer = false;
    }
    protected virtual void Activate()
    {
        if (!m_isCollidingWithPlayer) return;
        activateEvent?.Invoke();
    }
}
