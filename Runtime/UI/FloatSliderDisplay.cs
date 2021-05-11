using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

[RequireComponent(typeof(Slider))]
public class FloatSliderDisplay : MonoBehaviour
{
    private Slider m_slider;

    [SerializeField] private FloatReference floatReference;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();
        if (floatReference == null) gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Assert(m_slider != null, nameof(m_slider) + " != null");
        Debug.Assert(floatReference != null, nameof(floatReference) + " != null");
        m_slider.value = floatReference.Value;
    }
}
