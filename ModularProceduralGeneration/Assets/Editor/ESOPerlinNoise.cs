using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(SOPerlinNoiseData))]
public class ESOPerlinNoise : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        SOPerlinNoiseData window = (SOPerlinNoiseData)target;
        if (DrawDefaultInspector())
        {
            if (window.autoUpdate)
            {
                window.OnGenerateTexturePreview();
            }
        }

        if (GUILayout.Button("GenerateMap"))
        {
            window.OnGenerateTexturePreview();

        }

        GUILayout.Box(window.texurePreview);

    }
}
