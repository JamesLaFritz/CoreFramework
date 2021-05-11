using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CoolDownTimerDisplay : MonoBehaviour
{
    private Slider m_slider;

    public FloatReference coolDownTimer;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();

        if (m_slider == null || coolDownTimer == null)
        {
            gameObject.SetActive(false);
            return;
        }

        coolDownTimer.Value = 0;
    }

    private void Update()
    {
        Debug.Assert(m_slider != null, nameof(m_slider) + " != null");
        Debug.Assert(coolDownTimer != null, nameof(coolDownTimer) + " != null");
        m_slider.value = coolDownTimer.Value;
    }
}
