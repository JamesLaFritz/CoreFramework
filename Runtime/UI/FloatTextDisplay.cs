using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

[RequireComponent(typeof(Text))]
public class FloatTextDisplay : MonoBehaviour
{
    private Text m_text;

    [SerializeField] private string message = "";
    [SerializeField] private FloatReference floatReference;

    private void Awake()
    {
        m_text = GetComponent<Text>();

        if (floatReference == null) gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Assert(m_text != null, nameof(m_text) + " != null");
        Debug.Assert(floatReference != null, nameof(floatReference) + " != null");
        m_text.text = $"{message} {floatReference.Value:00.00}";
    }
}
