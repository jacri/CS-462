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

    public void SpawnInstance (Vector3 pos)
    {
        instance = Instantiate(prefab, pos, respawnRotation);
    }
    
    public void SpawnInstance (Vector3 pos, Quaternion rot)
    {
        instance = Instantiate(prefab, pos, rot);
    }

    public void Respawn ()
    {
        DestroyInstance();
        SpawnInstance();
    }
}
