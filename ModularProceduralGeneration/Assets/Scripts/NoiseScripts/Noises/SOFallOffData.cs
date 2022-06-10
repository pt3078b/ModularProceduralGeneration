using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ModuleTerrain/FallOff Noise Data")]
public class SOFallOffData : VINoise
{

    public int mapHeight = 100;
    public int mapWidth = 100;
    [Range(0.01f, 20f)]
    public float fallOffEdge = 5f;
    [Range(0.01f, 20f)]
    public float fallOffOuter = 3f;

    public bool invert = true;
    public bool radial = false;


    [HideInInspector]
    public Texture2D texurePreview;

    [Header("Preview")]
    [Tooltip("True: Changes in inpector automatically generate terrain")]
    public bool autoUpdate = true;
    // Preview Image Shown
    public void OnGenerateTexturePreview()
    {
        texurePreview = NoiseMapToTexture2D.OnNoiseMapToTexture(CentreFallOffNoise.OnGenerateFallOffMap(mapWidth, mapHeight, invert, fallOffEdge, fallOffOuter, radial));
    }

    public override float[,] OnGetNoiseMap()
    {
        return CentreFallOffNoise.OnGenerateFallOffMap(mapWidth, mapHeight, invert, fallOffEdge, fallOffOuter, radial);
    }

    public override float[,] OnGetNoiseMApWithOffset(Vector2 newOffset, bool dontNormalize)
    {
        return CentreFallOffNoise.OnGenerateFallOffMap(mapWidth, mapHeight, invert, fallOffEdge, fallOffOuter, radial);

    }


}
