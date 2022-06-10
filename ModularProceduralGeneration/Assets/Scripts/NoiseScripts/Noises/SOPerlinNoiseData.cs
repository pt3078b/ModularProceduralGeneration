using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ModuleTerrain/Perlin Noise Data")]
public class SOPerlinNoiseData : VINoise
{
    public int mapHeight = 100;
    public int mapWidth = 100;
    public float noiseScale = 30f;
    public float lacunarity = 2f;
    [Range(0, 1)]
    public float persistance = 0.5f;
    [Range(1, 25)]
    public int numberOfOctaves = 5;
    public Vector2 offset = Vector2.zero;
    public int seed = 1;

    [HideInInspector]
    public Texture2D texurePreview;

    [Header("Preview")]
    [Tooltip("True: Changes in inpector automatically generate terrain")]
    public bool autoUpdate = true;
    // Preview Image Shown
    public void OnGenerateTexturePreview()
    {
        texurePreview =  NoiseMapToTexture2D.OnNoiseMapToTexture(PerlinNoise.OnGenerateNoiseMap(mapWidth, mapHeight, noiseScale, lacunarity, persistance, numberOfOctaves, offset, seed));
    }

    public override float[,] OnGetNoiseMap()
    {
        return PerlinNoise.OnGenerateNoiseMap(mapWidth, mapHeight, noiseScale, lacunarity, persistance, numberOfOctaves, offset, seed);
    }

    public override float[,] OnGetNoiseMApWithOffset(Vector2 newOffset, bool dontNormalize)
    {
        return PerlinNoise.OnGenerateNoiseMap(mapWidth, mapHeight, noiseScale, lacunarity, persistance, numberOfOctaves, (newOffset + offset), seed, dontNormalize);

    }


}

