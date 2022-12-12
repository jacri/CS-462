using UnityEngine;

public class DragonHealth : Health
{
    // ===== Public Functions =====================================================================

    public override void Die()
    {
        FindObjectOfType<Tower>().numEnemies--;
        GetComponent<DragonAI>().enabled = false;
        GetComponent<Animator>().SetTrigger("Die");
        slider.gameObject.SetActive(false);
        base.Die();
    }
}
