using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MasterModuleTerrain))]

public class Module_LowCutoff : ModuleBase , IModule
{

    [Tooltip("True: Normalizes height map data bettween 0 - 1")]
    public bool normalizePre = true;

    [Tooltip("Low step cutoff range, if a value is less than the cut off range it will be brought up to the cutoff range. This Process will automaticall normalize before completing the oporation")]
    [Range(0, 1)]
    [SerializeField] float lowCutOff = 0.3f;

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
                if (noiseMapInput[x,y] < lowCutOff)
                {
                    noiseMapInput[x, y] = lowCutOff;
                }

            }
        }


        if (normalizePost)
        {
            NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);
        }


        return noiseMapInput;
    }
}
