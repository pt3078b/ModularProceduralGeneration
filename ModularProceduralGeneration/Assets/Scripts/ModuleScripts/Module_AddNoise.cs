using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(MasterModuleTerrain))]
public class Module_AddNoise : ModuleBase, IModule
{
    [Tooltip("Noise Sample to multiply")]
    [SerializeField] public VINoise NoiseSample;

    [Tooltip("Stength of noise to add")]
    [Range(-5,5)]
    [SerializeField] public float strength = 0.5f;

    public float[,] OnIProcessMap(float[,] noiseMapInput)
    {
        int width = noiseMapInput.GetLength(0);
        int height = noiseMapInput.GetLength(1);

        // Check Noise is Valid

        float[,] otherMap = NoiseSample.OnGetNoiseMap();

        int otherWidth = otherMap.GetLength(0);
        int otherHeight = otherMap.GetLength(1);

        if (otherWidth < width) // Noise Too small
        {
            Debug.LogError("Noise Samples Mismatched, please insure the Width and Height Values are the same");
            return noiseMapInput;
        }
        if (otherHeight < height) // Noise too small
        {
            Debug.LogError("Noise Samples Mismatched, please insure the Width and Height Values are the same");
            return noiseMapInput;
        }


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                //  noiseMapInput[x, y] = (noiseMapInput[x, y] * (otherMap[x, y] *strength * 2)) / 2;

                 noiseMapInput[x, y] = noiseMapInput[x,y] + otherMap[x, y] * strength;

                // noiseMapInput[x, y] = ((noiseMapInput[x, y] * strength) + otherMap[x, y] * (1 - strength)) / 2;      ###### THIS IS MULTIPLY

            }
        }



        return noiseMapInput;
    }
}
