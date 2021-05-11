using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float m_timeToLive = 6;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        Destroy(gameObject, m_timeToLive);
    }
}
