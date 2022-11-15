using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public int maxHealth;
    public int currentHealth;
    public float deathAnimTime;
    public Slider slider;

    // ===== Public Functions =====================================================================

    public virtual void TakeDamage (int amnt)
    {
        currentHealth -= amnt;

        if (currentHealth <= 0)
            Die();

        slider.value = currentHealth;
    }

    public virtual void Die ()
    {
        Destroy(gameObject, deathAnimTime);
    }
}