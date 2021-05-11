using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Text))]
public class DisplayIntVariable : MonoBehaviour
{
    private Text m_text;

    [SerializeField] private string message = "Score: ";
    [SerializeField] private IntReference intReference;

    private void Awake()
    {
        m_text = GetComponent<Text>();
        if (intReference == null) gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Assert(m_text != null, nameof(m_text) + " != null");
        Debug.Assert(intReference != null, nameof(intReference) + " != null");
        m_text.text = message + intReference.Value;
    }
}