using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseMapToTexture2D 
{
    public static Texture2D OnNoiseMapToTexture(float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);


        Color[] noiseColourMap = new Color[width * height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Debug.Log(noiseMap[x, y]);
                noiseColourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);

            }
        }


        return OnColourMapToTexture(noiseColourMap, width, height);

    }

    public static Texture2D OnColourMapToTexture(Color[] colourMap, int width, int heigt)
    {
        Texture2D texture = new Texture2D(width, heigt);
        texture.filterMode = FilterMode.Bilinear;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

}
