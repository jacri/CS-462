using UnityEngine;

[System.Serializable]
public class Tile : MonoBehaviour
{
    // ===== Type Enum ============================================================================

    public enum Type
    {
        Forest = 0,
        Desert = 1,
        Tundra = 2,
        Village = 3,
        Tower = 4,
    }

    // ===== Public Variables =====================================================================

    public Type type;
    public int x;
    public int y;

    // ===== Private Variables ====================================================================

    private Renderer rend;
    private WorldGenerator worldGenerator;

    // ===== Tile Setup ===========================================================================

    public void SetCoords (int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void ChangeType (Type newType)
    {
        if (rend == null)
            rend = GetComponent<Renderer>();

        if (worldGenerator == null)
            worldGenerator = FindObjectOfType<WorldGenerator>();

        type = newType;
        rend.material = worldGenerator.biomeMaterials[newType];
    }
}