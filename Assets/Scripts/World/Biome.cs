using UnityEngine;

[System.Serializable]
public class Biome
{
    // ===== Public Variables =====================================================================

    public Biome() { }

    [Header("Biome Info")]

    public Tile.Type type;
    public GameObject tile;
    public Material material;
}