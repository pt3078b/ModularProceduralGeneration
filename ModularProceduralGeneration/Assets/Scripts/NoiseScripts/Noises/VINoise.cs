using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VINoise : ScriptableObject
{
    public virtual float[,] OnGetNoiseMap()
    {
        return null;
    }

    public virtual float[,] OnGetNoiseMApWithOffset(Vector2 newOffset, bool dontNormalize)
    {
        return null;
    }

}
