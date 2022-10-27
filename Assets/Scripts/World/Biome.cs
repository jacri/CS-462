using UnityEngine;

[System.Serializable]
public class Biome
{
    // ===== Public Variables =====================================================================

    public Biome() { }

    [Header("Biome Info")]

    public Tile.Type type;
    public GameObject[] tiles;
    public Material material;

    // ===== Public Functions =====================================================================

    public GameObject GetTile () => tiles[WorldGenerator.rand.Next(0, tiles.Length)];
}