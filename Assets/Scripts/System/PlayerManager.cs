using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // ===== Public Variables =====================================================================
    
    public bool playerExists;
    public GameObject prefab;
    public GameObject instance; 
    public Vector3 respawnPosition;
    public Quaternion respawnRotation;

    // ===== Start ================================================================================
    
    private void Start ()
    {
        SpawnInstance();
    }

    // ===== Update ===============================================================================
    
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    // ===== Public Functions =====================================================================

    public void DestroyInstance ()
    {
        Destroy(instance);
        playerExists = false;
    }

    public void SpawnInstance ()
    {
        instance = Instantiate(prefab, respawnPosition, respawnRotation);
        playerExists = true;
    }

    public void SpawnInstance (int damage)
    {
        instance = Instantiate(prefab, respawnPosition, respawnRotation);
        PlayerHealth h = instance.GetComponentInChildren<PlayerHealth>();
        h.TakeDamage(h.maxHealth - damage);
        playerExists = true;
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
