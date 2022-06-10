using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CentreFallOffNoise 
{
    public static float[,] OnGenerateFallOffMap(int mapWidth, int mapHeight, bool invert, float falloffInner, float falloffOuter, bool radial)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        if (radial == false)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    float xPos = i / (float)mapWidth * 2 - 1;
                    float yPos = j / (float)mapHeight * 2 - 1;

                    float higherValue = Mathf.Max(Mathf.Abs(xPos), Mathf.Abs(yPos));

                    if (invert)
                    {
                        higherValue = 1 - higherValue;
                    }

                    noiseMap[i, j] = OnCalculateAgainstCurve(higherValue, falloffInner, falloffOuter);
                }
            }

            return noiseMap;

        }
        else
        {
            Vector2 centrepoint = new Vector2(mapWidth * 0.5f, mapHeight * 0.5f);


            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    float distanceFromCentre = Vector2.Distance(centrepoint, new Vector2(i, j));
                    float value = (0.5f - (distanceFromCentre / mapWidth) * falloffOuter/5f);
                    noiseMap[i, j] = value * Mathf.InverseLerp(0.01f, 20f, falloffInner);

                    if (noiseMap[i,j] < 0.01f)
                    {
                        noiseMap[i, j] = 0f;
                    }

                    if (invert)
                    {
                        noiseMap[i,j] = 1 - noiseMap[i, j];
                    }


                }
            }


           // NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMap);

            return noiseMap;
        }

    }

    static float OnCalculateAgainstCurve(float value, float falloffInner, float falloffOuter)
    {
    
        float temp = Mathf.Pow(value, falloffOuter) / (Mathf.Pow(value, falloffOuter) + Mathf.Pow(falloffInner - falloffInner * value, falloffOuter));

        return temp;
    }

}
