using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Slider))]
public class StatSliderDisplay : MonoBehaviour
{
    private Slider m_slider;
    private Text m_statText;
    private bool m_hasText;

    [SerializeField] private string statName = "Stat";

    [SerializeField] private StatReference stat;

    [SerializeField] private CodedGameEventListener statUpdateGameEventListener;

    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    private bool m_hasFillImage, m_hasGradient;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();

        if (stat == null || m_slider == null)
        {
            gameObject.SetActive(false);
        }

        m_statText = GetComponentInChildren<Text>();

        m_hasText = m_statText != null;
        m_hasFillImage = fill != null;
        m_hasGradient = fill != null;
    }

    private void Start()
    {
        UpdateDisplay();
    }

    private void OnDisable()
    {
        if (statUpdateGameEventListener != null) statUpdateGameEventListener.OnDisable();
    }

    private void OnEnable()
    {
        if (statUpdateGameEventListener != null) statUpdateGameEventListener.OnEnable(UpdateDisplay);
    }

    private void UpdateDisplay()
    {
        Debug.Assert(m_slider != null, nameof(m_slider) + " != null");
        Debug.Assert(stat != null, nameof(stat) + " != null");
        m_slider.maxValue = stat.Max;
        m_slider.value = stat.Value;
        if (m_hasFillImage && m_hasGradient)
        {
            Debug.Assert(fill != null, nameof(fill) + " != null");
            Debug.Assert(gradient != null, nameof(gradient) + " != null");
            fill.color = gradient.Evaluate(m_slider.normalizedValue);
        }

        if (!m_hasText) return;
        Debug.Assert(m_statText != null, nameof(m_statText) + " != null");
        m_statText.text = statName + ": " + stat;
    }
}
