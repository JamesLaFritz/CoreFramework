using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float m_damageAmount = 1f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        OnTriggerDamage(other.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerDamage(other.transform);
    }

    private void OnTriggerDamage(Transform other)
    {
        // if collided with a damageable object do damage.
        IDamageable damageable = other.GetComponent<IDamageable>();
        // If Damageable is null there is nothing to damage exit
        if (damageable == null)
        {
            Debug.Log($"{other.name} is not a damageable object.");
            return;
        }

        DamageInfo damgeInfo = new DamageInfo(m_damageAmount, gameObject,
                                             (other.position - transform.position).normalized);

        damageable.Hit(damgeInfo);
    }
}
