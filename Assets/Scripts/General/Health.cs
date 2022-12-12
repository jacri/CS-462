using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public int maxHealth;
    public int currentHealth;
    public float deathAnimTime;
    public Slider slider;
    public AudioSource takeDamageSound;
    public AudioSource deathSoundEffect;

    // ===== Public Functions =====================================================================

    public virtual void TakeDamage (int amnt)
    {
        if (takeDamageSound != null)
            takeDamageSound.Play();

        currentHealth -= amnt;

        if (currentHealth <= 0)
            Die();

        slider.value = currentHealth;
    }

    public virtual void Die ()
    {
        if (deathSoundEffect != null)
            deathSoundEffect.Play();

        Destroy(gameObject, deathAnimTime);
    }
}