using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MasterModuleTerrain))]
public class Module_SampleModule : ModuleBase , IModule
{
    [SerializeField] float scaleValue = 30f;

    [Tooltip("True: Normalizes height map data bettween 0 - 1")]
    public bool normalize = true;

    public float[, ] OnIProcessMap(float[,] noiseMapInput)
    {
        int width = noiseMapInput.GetLength(0);
        int height = noiseMapInput.GetLength(1);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                noiseMapInput[x, y] = noiseMapInput[x, y] * scaleValue;

            }
        }


        if (normalize)
        {
            NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);
        }



        return noiseMapInput;
    }
}
