using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise 
{
    public static float[,] OnGenerateNoiseMap(int mapWidth, int mapHeight, float noiseScale, float lacunarity, float persistance, int numOctaves, Vector2 offset, int seed)
    {
        if (noiseScale <= 0)
        {
            noiseScale = 0.001f; // Makes sure no division by zero occurs
            // Debug.Log(noiseScale);
        }

        System.Random rndSeed = new System.Random(seed);

        Vector2[] octavesOffsets = new Vector2[numOctaves];
        for (int i = 0; i < numOctaves; i++)
        {
            float offsetX = rndSeed.Next(-100000, 100000) + offset.x;
            float offsetY = rndSeed.Next(-100000, 100000) + offset.y;

            octavesOffsets[i] = new Vector2(offsetX, offsetY);
        }



        float[,] noiseMap = new float[mapWidth, mapHeight];



        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;


        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++) // Loop through 2d array
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;


                for (int i = 0; i < numOctaves; i++)
                {
                    float sampleX = (x - mapWidth / 3) / (noiseScale) * frequency + octavesOffsets[i].x; // Stops repeated values
                    float sampleY = (y - mapHeight / 3) / (noiseScale) * frequency + octavesOffsets[i].y;

                    float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                    noiseHeight += perlinNoise * amplitude;

                    amplitude *= persistance; //Goes down
                    frequency *= lacunarity; // Goes Up
                }

                // Normilizing values

                if (noiseHeight > maxNoiseHeight) // Checks if this pixles noise is the heightest or lowest in the array
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight; // Sets value of pixle
            }
        }

        for (int x = 0; x < mapWidth; x++) // Loop through 2d array and normalize
        {
            for (int y = 0; y < mapHeight; y++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);

            }
        }

        return noiseMap;

    }

    public static float[,] OnGenerateNoiseMap(int mapWidth, int mapHeight, float noiseScale, float lacunarity, float persistance, int numOctaves, Vector2 offset, int seed, bool dontNormalize)
    {
        if (noiseScale <= 0)
        {
            noiseScale = 0.001f; // Makes sure no division by zero occurs
            // Debug.Log(noiseScale);
        }

        System.Random rndSeed = new System.Random(seed);

        Vector2[] octavesOffsets = new Vector2[numOctaves];
        for (int i = 0; i < numOctaves; i++)
        {
            float offsetX = rndSeed.Next(-100000, 100000) + offset.x;
            float offsetY = rndSeed.Next(-100000, 100000) + offset.y;

            octavesOffsets[i] = new Vector2(offsetX, offsetY);
        }



        float[,] noiseMap = new float[mapWidth, mapHeight];



        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;


        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++) // Loop through 2d array
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;


                for (int i = 0; i < numOctaves; i++)
                {
                    float sampleX = (x - mapWidth / 3) / (noiseScale) * frequency + octavesOffsets[i].x; // Stops repeated values
                    float sampleY = (y - mapHeight / 3) / (noiseScale) * frequency + octavesOffsets[i].y;

                   // float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY);

                    noiseHeight += perlinNoise * amplitude;

                    amplitude *= persistance; //Goes down
                    frequency *= lacunarity; // Goes Up
                }

                // Normilizing values

                if (noiseHeight > maxNoiseHeight) // Checks if this pixles noise is the heightest or lowest in the array
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight; // Sets value of pixle
            }
        }

        for (int x = 0; x < mapWidth; x++) // Loop through 2d array and normalize
        {
            for (int y = 0; y < mapHeight; y++)
            {
              //  noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);

            }
        }

        return noiseMap;

    }





}
