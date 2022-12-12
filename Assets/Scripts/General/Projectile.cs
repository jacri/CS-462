using UnityEngine;

public class Projectile : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public int damage;

    // ===== Collision ============================================================================

    private void OnCollisionEnter (Collision col)
    {
        if (col.collider.GetComponent<Health>())
            col.collider.GetComponent<Health>().TakeDamage(damage);

        else if (col.collider.name.Contains("tower"))
            FindObjectOfType<MenuManager>().ShowWinScreen();

        Destroy(gameObject);
    }
}
