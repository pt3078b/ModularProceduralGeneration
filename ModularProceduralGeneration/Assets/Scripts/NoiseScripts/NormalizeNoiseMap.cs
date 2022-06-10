using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NormalizeNoiseMap 
{
    public static float[,] OnNormalizeNoiseMap(float[,] noiseMapInput)
    {
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        int width = noiseMapInput.GetLength(0);
        int height = noiseMapInput.GetLength(1);

        // Loop over and find max and min heights of noise map
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                if (noiseMapInput[x,y] > maxNoiseHeight) // Gets max value
                {
                    maxNoiseHeight = noiseMapInput[x, y];
                }
                else if(noiseMapInput[x,y] < minNoiseHeight) // Gets min value
                {
                    minNoiseHeight = noiseMapInput[x, y];
                }

            }
        }

        for (int x = 0; x < width; x++) // Loop through 2d array and normalize
        {
            for (int y = 0; y < height; y++)
            {
                noiseMapInput[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMapInput[x, y]);

            }
        }


        return noiseMapInput;
    }
}
