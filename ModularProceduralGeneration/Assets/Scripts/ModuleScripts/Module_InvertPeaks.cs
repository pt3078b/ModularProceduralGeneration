using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MasterModuleTerrain))]
public class Module_InvertPeaks : ModuleBase , IModule
{
    [Tooltip("True: Normalizes height map data bettween 0 - 1")]
    public bool normalizePre = true;

    [Tooltip("High step cutoff range, if a value is more than the cut off range it will be inverted after the cutoff range. This Process will automaticall normalize before completing the oporation")]
    [Range(0, 1)]
    [SerializeField] float highCutOff = 0.8f;

    [Range(0, 3)]
    [Tooltip("Strength of inversion of peaks, 0 = No inversion, 1 = Fully inverted ")]
    [SerializeField] float invertStrength = 1f;

    [Tooltip("True: Normalizes height map data bettween 0 - 1")]
    public bool normalizePost = true;
    

    public float[,] OnIProcessMap(float[,] noiseMapInput)
    {
        int width = noiseMapInput.GetLength(0);
        int height = noiseMapInput.GetLength(1);

        if (normalizePre)
        {
            NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);

        }



        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (noiseMapInput[x, y] > highCutOff)
                {
                    float distance = Mathf.Abs(noiseMapInput[x, y] - highCutOff);
                    noiseMapInput[x, y] = noiseMapInput[x,y] - distance * 2 * invertStrength;
                }

            }
        }

        // Static class that normalizes the array
        if (normalizePost)
        {
            NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);
        }


        return noiseMapInput;
    }
}
