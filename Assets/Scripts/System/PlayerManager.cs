using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // ===== Public Variables =====================================================================
    
    public GameObject prefab;
    public GameObject instance; 
    public Vector3 respawnPosition;
    public Quaternion respawnRotation;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        SpawnInstance();
    }

    // ===== Public Functions =====================================================================

    public void DestroyInstance ()
    {
        Destroy(instance);
    }

    public void SpawnInstance ()
    {
        instance = Instantiate(prefab, respawnPosition, respawnRotation);
    }

    public void SpawnInstance (int damage)
    {
        instance = Instantiate(prefab, respawnPosition, respawnRotation);
        PlayerHealth h = instance.GetComponentInChildren<PlayerHealth>();
        h.TakeDamage(h.maxHealth - damage);
    }

    public void Respawn ()
    {
        DestroyInstance();
        SpawnInstance();
    }

    public void Respawn (int health)
    {
        DestroyInstance();
        SpawnInstance(health);
    }
}
