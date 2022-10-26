using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    [Header("World Settings")]

    public int seed;
    public int numIslands;
    public int minDistance;
    public int maxDistance;
    public GameObject[] islands; 

    // ===== Private Variables =====================================================================

    private int islandCount = 0;

    private Transform t;
    private System.Random rand;
    private Vector3 lastIsland = Vector3.zero;

    // ===== Awake ================================================================================
    
    private void Awake ()
    {
        if (seed == 0)
            seed = System.DateTime.Now.Millisecond * System.DateTime.Now.Second;
    }

    // ===== Start ================================================================================
    
    private void Start ()
    {
        t = transform;
        rand = new System.Random(seed);

        GenerateWorld();
    }

    // ===== Generate World =======================================================================

    private void GenerateWorld ()
    {
        while (islandCount < numIslands)
        {
            GenerateIsland();
        }
            
    }

    private void GenerateIsland ()
    {
        int i = Random.Range(0, islands.Length);
        float x = rand.Next(maxDistance * -100, maxDistance * 100) / 100f;
        float z = rand.Next(maxDistance * -100, maxDistance * 100) / 100f;

        Vector3 pos = lastIsland + new Vector3(x, 0f, z);
        if (!Physics.BoxCast(pos, Vector3.one * 10f, Vector3.forward, Quaternion.identity))
        {
            islandCount++;
            lastIsland += new Vector3(x, 0f, z);
            Instantiate(islands[i], lastIsland, Quaternion.identity, t);
        }
    }
}
