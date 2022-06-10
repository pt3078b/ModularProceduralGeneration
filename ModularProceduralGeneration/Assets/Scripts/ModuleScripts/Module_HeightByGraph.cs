using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MasterModuleTerrain))]
public class Module_HeightByGraph : ModuleBase, IModule
{
    public bool normalizePre = true;

    [SerializeField] public AnimationCurve heightCurve;

    [Range(0,1)]
    public float lowerEffectBound = 0f;

    [Range(0,1)]
    public float upperEffectBound = 1f;




    public float [,] OnIProcessMap(float[,] noiseMapInput)
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
                if (noiseMapInput[x,y] < upperEffectBound && noiseMapInput[x,y] > lowerEffectBound)
                {
                    float temp = heightCurve.Evaluate(noiseMapInput[x, y]);

                    noiseMapInput[x, y] = noiseMapInput[x, y] * temp;
                }

            }
        }




        return noiseMapInput;
    }

    public void OnValidate()
    {
        if (lowerEffectBound > upperEffectBound)
        {
            lowerEffectBound = upperEffectBound - 0.01f;
        }

        if (upperEffectBound < lowerEffectBound)
        {
            upperEffectBound = lowerEffectBound + 0.01f;
        }


    }

    public  Module_HeightByGraph()
    {
        heightCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        heightCurve.MoveKey(0, new Keyframe(lowerEffectBound, 0f));

        int num = heightCurve.keys.Length;
        heightCurve.MoveKey(num - 1, new Keyframe(upperEffectBound, 1f));
    }

}
