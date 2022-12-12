using UnityEngine;

public class Tower : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    public int numEnemies;
    public GameObject enemy;

    // ===== Private Variables =====================================================================

    private Transform t;

    // ===== Generate =============================================================================
    
    // public void Generate ()
    // {
    //     t = transform;

    //     for (int i = 0; i < numEnemies; i++)
    //     {
    //         Instantiate(enemy, transform.position + new Vector3(Random.Range(2f, 5f), 3f, Random.Range(2f, 5f)), Quaternion.identity);
    //     }
    // }
    
    // // ===== Update ===============================================================================

    // private void Update ()
    // {
    //     if (numEnemies == 0)
    //         FindObjectOfType<MenuManager>().ShowWinScreen();
    // }
}
