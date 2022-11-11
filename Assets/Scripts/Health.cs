using UnityEngine;

public class Health : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public int maxHealth;
    public int currentHealth;

    // ===== Public Functions =====================================================================

    public virtual void TakeDamage (int amnt)
    {
        currentHealth -= maxHealth;

        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die ()
    {
        Destroy(gameObject);
    }
}