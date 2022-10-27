using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour
{
    // ===== Public Variables =====================================================================

    [Header("World Settings")]

    public int width;
    public int height;
    public string seed;
    public Vector3 worldScale = Vector3.one;
    public GameObject generatingWorldUI;

    [Space(10)]
    [Header("Noise Settings")]

    public float xOrg;
    public float yOrg;
    public float noiseScale;

    [Space(10)]

    public GeneralBiome[] genBiomes;
    public LocalizedBiome[] localBiomes;

    // ===== Hidden Variables =====================================================================

    public static System.Random rand;
    public Dictionary<Tile.Type, Material> biomeMaterials;

    // ===== Private Variables =====================================================================

    private int seedInt;
    private Tile[,] terrainTiles;
    private float[,] terrainHeight;

    // ===== Awake ================================================================================
    
    private void Awake ()
    {
        generatingWorldUI.SetActive(true);
    }

    // ===== Start ================================================================================

    private void Start ()
    {
        GenerateWorld();
    }

    // ===== World Generation =====================================================================

    public void GenerateWorld ()
    {
        ClearWorld();
        StartCoroutine(Generate());
    }

    public IEnumerator Generate ()
    {
        terrainTiles = new Tile[width, height];
        terrainHeight = new float[width, height];
        biomeMaterials = new Dictionary<Tile.Type, Material>();

        SetSeed();
        GenerateTerrainHeight();
        PlaceTiles();

        yield return new WaitForSeconds(0.01f);

        GenerateBiomes();

        yield return new WaitForSeconds(0.01f);

        transform.localScale = worldScale;
        generatingWorldUI.SetActive(false);
    }

    private void ClearWorld ()
    {
        if (transform.childCount == 0)
            return;

        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }

    private void SetSeed ()
    {
        if (seed == "")
        {
            var t = System.DateTime.Now;
            seed = "0" + Mathf.RoundToInt(t.Day * t.Second * Time.deltaTime % t.Millisecond * t.Second).ToString();
            seedInt = int.Parse(seed);
        }

        rand = new System.Random(seedInt);
        xOrg = rand.Next(-seedInt, seedInt);
        yOrg = rand.Next(-seedInt, seedInt);
    }

    private void GenerateTerrainHeight ()
    {
        float y = 0;

        while (y < height)
        {
            float x = 0;

            while (x < width)
            {
                float xCoord = xOrg + x / width * noiseScale;
                float yCoord = yOrg + y / height * noiseScale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                terrainHeight[(int)x, (int)y] = sample;
                x++;
            }

            y++;
        }
    }

    private void PlaceTiles ()
    {
        bool gen = false;
        GameObject tile = genBiomes[0].GetTile();

        for (int y = 0; y < height; y++) 
        {
            for (int x = 0; x < width; x++)
            {
                foreach (GeneralBiome b in genBiomes)
                {
                    if (terrainHeight[x, y] >= b.minElevation && terrainHeight[x, y] < b.maxElevation)
                    {
                        gen = true;
                        tile = b.GetTile();
                        break;
                    }
                }

                if (gen)
                {
                    terrainTiles[x, y] = Instantiate(tile, new Vector3(y % 2 == 0 ? x : x + 0.5f, 0, y * 0.87f), Quaternion.Euler(-90f, 0f, 0f), transform).GetComponent<Tile>();
                    terrainTiles[x, y].SetCoords(x, y);
                }

                gen = false;          
            }
        }
    }

    private async void GenerateBiomes ()
    {
        foreach (Biome b in genBiomes)
            biomeMaterials.Add(b.type, b.material);

        foreach (Biome b in localBiomes)
            biomeMaterials.Add(b.type, b.material);

        await System.Threading.Tasks.Task.Delay(10);

        foreach (LocalizedBiome b in localBiomes)
            GenerateLocalizedBiome(rand.Next(b.minZones, b.maxZones), b.zoneSize, b);
    }

    private void GenerateLocalizedBiome (int numZones, float radius, LocalizedBiome biome)
    {
        void Generate(Vector3 pos)
        {
            foreach (Collider col in Physics.OverlapSphere(pos, radius))
            {
                Tile t = col.GetComponent<Tile>();

                if ((int)t.type > 0)
                    t.ChangeType(biome.type);
            }
        }

        for (int i = 0; i < numZones; i++)
        {
            Vector3 pos = new Vector3(rand.Next(0, width), 0, rand.Next(0, height));
            Generate(pos);

            for (int j = 0; j < rand.Next(1, (int)radius * 2); j++)
            {
                Vector3 offset = new Vector3(rand.Next(-(int)(radius / 2), (int)(radius / 2)), 0f, rand.Next(-(int)(radius / 2), (int)(radius / 2)));
                Generate(pos + offset);
            }  
        }
    }

    public void Quit ()
    {
        Application.Quit();
    }
}