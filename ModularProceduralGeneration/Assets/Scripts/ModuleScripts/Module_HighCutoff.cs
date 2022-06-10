using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MasterModuleTerrain))]
public class Module_HighCutoff : ModuleBase , IModule
{
    [Tooltip("High step cutoff range, if a value is more than the cut off range it will be brought down to the cutoff range. This Process will automaticall normalize before completing the oporation")]
    [Range(0, 1)]
    [SerializeField] float highCutOff = 0.8f;

    [Tooltip("True: Normalizes height map data bettween 0 - 1")]
    public bool normalize = true;

    public float[,] OnIProcessMap(float[,] noiseMapInput)
    {
        int width = noiseMapInput.GetLength(0);
        int height = noiseMapInput.GetLength(1);


        NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (noiseMapInput[x, y] > highCutOff)
                {
                    noiseMapInput[x, y] = highCutOff;
                }

            }
        }

        // Static class that normalizes the array
        if (normalize)
        {
            NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);
        }


        return noiseMapInput;
    }
}
