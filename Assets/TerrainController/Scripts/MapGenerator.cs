using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MapGenerator : MonoBehaviour
{
    public Terrain m_terrain;

    [Header("Generator Preset")]
    public float m_noiseScale = 27;
    public int m_octaves = 4;
    [Range(0,1)]
    public float m_persistance = .5f;
    public float m_lacunarity = 2;

    public int m_seed;
    public Vector2 m_offset;

    public AnimationCurve m_falloffCurve;

    [Header("Trees")]
    public float m_treeSpacing;

    [Range(0, 1)]
    public float m_forestCoverage;
    [Range(0,1)]
    public float m_maxSlopeForTrees = .6f;
    public int m_ForestNoiseMultiplier = 2;

    public List<Vegetation> m_treeRanges = new List<Vegetation>();

    private List<GameObject> m_treeLayers = new List<GameObject>();

    [Header("Events")]
    public GameEvent m_TerrainGenerated;

    public void DrawMesh(float[,] heightmap)
    {
        m_terrain.terrainData.SetHeightsDelayLOD(0, 0, heightmap);
    }

    public void DrawMeshEditor(float[,] heightmap)
    {
        m_terrain.terrainData.SetHeights(0, 0, heightmap);
    }


    public void SpawnTrees()
    {
        System.Random prng = new System.Random();
        OpenSimplexNoise simplexGen = new OpenSimplexNoise(m_seed);
        Vector2 offset = new Vector2(prng.Next(-10000, 10000), prng.Next(-10000, 10000));
        Vector3 size = m_terrain.terrainData.size;
        List<Vector3> treeLocations = new List<Vector3>();
        float treeNoiseScale = m_noiseScale * m_ForestNoiseMultiplier;

        float randomTreeChance = 0;
        for (float x = 0; x < size.x; x += m_treeSpacing)
        {
            for (float z = 0; z < size.z; z += m_treeSpacing)
            {
                float chance = (float)(simplexGen.Evaluate(x/treeNoiseScale + offset.x, z/treeNoiseScale + offset.y) * 0.5 + 0.5);
                if (chance < m_forestCoverage || randomTreeChance > 1 - m_forestCoverage)
                {
                    Vector3 placement = new Vector3(
                        Random.Range(x, x + m_treeSpacing),
                        m_terrain.terrainData.size.y, 
                        Random.Range(z, z + m_treeSpacing)
                    );

                    RaycastHit hit;
                    int mask = 1 << LayerMask.NameToLayer("ProcTerrain");
                    Vector3 endLocation = placement;
                    endLocation.y = m_terrain.transform.position.y;

                    if (Physics.Linecast(placement, endLocation, out hit, mask) && Vector3.Dot(hit.normal, Vector3.up) > m_maxSlopeForTrees)
                    {
                        treeLocations.Add(hit.point);
                    }
                    if (randomTreeChance > 1 - m_forestCoverage)
                    {
                        randomTreeChance = 0;
                    }
                } else {
                    randomTreeChance += Random.Range(0, .2f*m_forestCoverage);
                }
            }
        }

        m_treeRanges.ForEach((range) =>
        {
            List<Vector3> viableLocations = treeLocations.FindAll((location) => (location.y < range.maxHeight && location.y > range.minHeight));

            List<GameObject> treesToPlant = new List<GameObject>();
            var obj = new GameObject(range.name);
            obj.transform.SetParent(m_terrain.transform);
            obj.isStatic = true;
            m_treeLayers.Add(obj);

            foreach (Vector3 location in viableLocations)
            {
                var tempLoc = location;
                tempLoc.y += range.verticalAdjust;
                Quaternion rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

                GameObject tree = Instantiate(range.treeTypes[Random.Range(0, range.treeTypes.Count)], tempLoc, rotation, obj.transform);
                tree.isStatic = true;
            }
        });
    }

    public void GenerateMapWithRandomSeed()
    {
        m_seed = Random.Range(0, 99999);
        GenerateMap();
    }

    public void GenerateMap(bool editor = false)
    {
        DeleteTrees(editor);
        int heightmapRes = m_terrain.terrainData.heightmapResolution;

        float[,] noiseMap = Noise.GenerateNoiseMap(heightmapRes, m_seed, m_noiseScale, m_octaves, m_persistance, m_lacunarity, m_offset);

        if (editor)
        {
            noiseMap = Noise.ApplyFalloff(noiseMap, m_falloffCurve);
            DrawMeshEditor(noiseMap);
            SpawnTrees();
        }
        else
        {
            noiseMap = Noise.ApplyFalloff(noiseMap, m_falloffCurve);
            DrawMesh(noiseMap);
        }

        m_TerrainGenerated.Raise();
    }


    private void DeleteTrees(bool editor = false)
    {
        for(int i = m_treeLayers.Count - 1; i >= 0; i--)
        {
            if (editor)
                DestroyImmediate(m_treeLayers[i]);
            else
                Destroy(m_treeLayers[i]);
        }

        m_treeLayers = new List<GameObject>();

        int children = m_terrain.transform.childCount;
        for (var i = children - 1; i >= 0; i--)
        {
            if (editor)
                DestroyImmediate(m_terrain.transform.GetChild(i).gameObject);
            else
                Destroy(m_terrain.transform.GetChild(i).gameObject);
        }
    }

    private void OnValidate()
    {
        if (m_lacunarity < 1)
            m_lacunarity = 1;
        if (m_octaves < 0)
            m_octaves = 0;
        if (m_treeSpacing < 1)
            m_treeSpacing = 1;
    }
}
