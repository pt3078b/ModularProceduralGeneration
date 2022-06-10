using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MasterModuleTerrain))]
public class Module_Normalize : ModuleBase , IModule
{
    public float[,] OnIProcessMap(float[,] noiseMapInput)
    {
        NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMapInput);

        return noiseMapInput;
    }

}
