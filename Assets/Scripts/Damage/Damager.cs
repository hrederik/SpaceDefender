using UnityEngine;

public class Damager : MonoBehaviour
{
    public void Damage(GameObject target, int damage)
    {
        if (IsDamageable(target, out Damageable damageable))
        {
            damageable.TakeDamage(damage);
        }
    }

    private bool IsDamageable(GameObject target, out Damageable damageable)
    {
        damageable = target.GetComponent<Damageable>();
        return damageable != null;
    }
}
