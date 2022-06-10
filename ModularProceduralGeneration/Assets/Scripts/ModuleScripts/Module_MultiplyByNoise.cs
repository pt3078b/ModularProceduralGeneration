using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(MasterModuleTerrain))]
public class Module_MultiplyByNoise : ModuleBase, IModule
{
    [Tooltip("True: Normalizes height map data bettween 0 - 1")]
    public bool normalizePre = true;


    [Tooltip("Noise Sample to multiply")]
    [SerializeField] public VINoise NoiseSample;

    [Tooltip("Bias between original noise and new noise. 0 == Original noise, 0.5 == Average of the two noises, 1 == New Noise")]
    [Range(0, 1)]
    [SerializeField] public float strength = 0.5f;

    public float[,] OnIProcessMap(float[,] noiseMapInput)
    {
        int width = noiseMapInput.GetLength(0);
        int height = noiseMapInput.GetLength(1);

        if (normalizePre)
        {
            NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);

        }

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

               // noiseMapInput[x, y] = noiseMapInput[x, y] + otherMap[x, y] * strength;

                 noiseMapInput[x, y] = ((noiseMapInput[x, y] * (1-strength)) + otherMap[x, y] * strength) / 1;     // ###### THIS IS MULTIPLY

            }
        }



        return noiseMapInput;
    }
}
